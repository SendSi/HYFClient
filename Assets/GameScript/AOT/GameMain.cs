using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using YooAsset;
using System;
using HybridCLR;
using System.Linq;

public class GameMain : MonoBehaviour
{
    /// <summary> 资源系统运行模式 </summary>
    public EPlayMode PlayMode = EPlayMode.HostPlayMode;

    public static GameMain Instance;

    void Awake()
    {
        Instance = this;
        Debuger.Log($"资源系统运行模式：{PlayMode}");
        Application.targetFrameRate = 60;
        Application.runInBackground = true;
        DontDestroyOnLoad(this.gameObject);
    }

    IEnumerator Start()
    {
        // 初始化资源系统
        YooAssets.Initialize();
        Debuger.EnableLog = AppConfig.EnableLog;

        FairyGUI.GRoot.inst.SetContentScaleFactor(AppConfig.designResolutionX, AppConfig.designResolutionY, FairyGUI.UIContentScaler.ScreenMatchMode.MatchHeight); //设计尺寸
        this.gameObject.AddComponent<FairyGUI.SafeAreaUtils>();
#if UNITY_EDITOR
        yield return CheckSkipHFView(); //跳过 热更页面    开发时  就是要快一点见到页面
#else
        yield return CheckLoadYooHF();
#endif
        //若每次测的 AppConfig.appVersion = "v1.0"  则HYFClient/yoo目录不会被更新，因为版本号没变，所以不会去下载  已有时,则会判断增涨  所以结论 把HYFClient/yoo目录删除，每次都会去下载
        // yield return CheckLoadYooHF(); //UnityEditor下 若要测试Host手动改下 上面四行注释掉即可  打开这一行

        // 反射调用入口 
        Type uiType = mHotUpdateAssembly.GetType("UIGenBinder");
        uiType.GetMethod("BindAll").Invoke(null, null);

        Type entryType = mHotUpdateAssembly.GetType("HotFixReflex");
        entryType.GetMethod("Run").Invoke(null, null);

        FairyGUI.Timers.inst.Add(1, 1, obj =>
        {
            ProxyHotPKGModule.Instance.CloseHFView(); //移除
            FairyGUI.UIConfig.globalModalWaiting = "ui://CommonPKG/GlobalModalWaiting";
        });
    }

    private void OnDestroy()
    {
        if (mHotUpdateAssembly != null)
        {
            Type entryType = mHotUpdateAssembly.GetType("HotFixReflex");
            entryType.GetMethod("Destroy").Invoke(null, null);
        }
    }

    //加载热更页面
    private IEnumerator CheckLoadYooHF()
    {
        // 加载更新页面
        ProxyHotPKGModule.Instance.OpenHFView();
        // 开始补丁更新流程
        // PatchOperation operation = new PatchOperation("DefaultPackage", EDefaultBuildPipeline.BuiltinBuildPipeline.ToString(), PlayMode);
        PatchOperation operation = new PatchOperation(AppConfig.defaultYooAssetPKG, EDefaultBuildPipeline.BuiltinBuildPipeline.ToString(), PlayMode);
        YooAssets.StartOperation(operation);
        yield return operation;
        //更新热更代码
        PatchOperation operation_hotFix = new PatchOperation("HotFixPackage", EDefaultBuildPipeline.RawFileBuildPipeline.ToString(), PlayMode);
        YooAssets.StartOperation(operation_hotFix);
        yield return operation_hotFix;

        //加载元数据 和 热更代码
        yield return LoadHotFixRes();
        LoadMetadataForAOTAssemblies();

        var gamePackage = YooAssets.GetPackage(AppConfig.defaultYooAssetPKG); //"DefaultPackage");
        YooAssets.SetDefaultPackage(gamePackage);
    }

    //跳过热更页面
    private IEnumerator CheckSkipHFView()
    {
        var package = YooAssets.CreatePackage(AppConfig.defaultYooAssetPKG); //"DefaultPackage");
        YooAssets.SetDefaultPackage(package);
        var createParameters = new EditorSimulateModeParameters();
        createParameters.SimulateManifestFilePath = EditorSimulateModeHelper.SimulateBuild(EDefaultBuildPipeline.BuiltinBuildPipeline.ToString(), AppConfig.defaultYooAssetPKG); //"DefaultPackage");
        var initializationOperation = package.InitializeAsync(createParameters);
        yield return initializationOperation;
        mHotUpdateAssembly = System.AppDomain.CurrentDomain.GetAssemblies().First(a => a.GetName().Name == "HotUpdate"); // Editor下无需加载，直接查找获得HotUpdate程序集
    }

    private IEnumerator LoadHotFixRes()
    {
        var hotfixPackage = YooAssets.GetPackage("HotFixPackage");
        foreach (var dll in mAssemblyFiles)
        {
            var handle = hotfixPackage.LoadRawFileAsync($"Assets/GameResHotFix/{dll}.bytes");
            yield return handle;
            var bytes = handle.GetRawFileData();
            mAssemblyBytesDic[dll] = bytes;
        }
    }
    public static byte[] ReadBytesFromStreamingAssets(string dllName)
    {
        return mAssemblyBytesDic[dllName];
    }
    private static Dictionary<string, byte[]> mAssemblyBytesDic = new Dictionary<string, byte[]>();//key=dllName.dll        value=bytes
    private static Assembly mHotUpdateAssembly;

    //PatchedAOTAssemblyList
    private static List<string> mAssemblyFiles { get; } = new List<string>()
    {
        "AOT.dll",
        "Google.Protobuf.dll",
        "Grpc.Core.Api.dll",
        "Newtonsoft.Json.dll",
        "System.Core.dll",
        "UnityEngine.CoreModule.dll",
        "UnityEngine.JSONSerializeModule.dll",
        "YooAsset.dll",
        "mscorlib.dll",

        "HotUpdate.dll", //不需使用 RuntimeApi.LoadMetadataForAOTAssembly(dllBytes, mode);加载
    };

    /// <summary>
    /// 为aot assembly加载原始metadata， 这个代码放aot或者热更新都行。
    /// 一旦加载后，如果AOT泛型函数对应native实现不存在，则自动替换为解释模式执行
    /// </summary>
    private static void LoadMetadataForAOTAssemblies()
    {
        /// 注意，补充元数据是给AOT dll补充元数据，而不是给热更新dll补充元数据。 热更新dll不缺元数据，不需要补充，如果调用LoadMetadataForAOTAssembly会返回错误
        HomologousImageMode mode = HomologousImageMode.SuperSet;
        for (int i = 0; i < mAssemblyFiles.Count-1; i++)
        {// 减一 最后一个是HotUpdate.dll  不是aot
            var dll= mAssemblyFiles[i];
            byte[] dllBytes = ReadBytesFromStreamingAssets(dll);
            // 加载assembly对应的dll，会自动为它hook。一旦aot泛型函数的native函数不存在，用解释器版本代码
            LoadImageErrorCode err = RuntimeApi.LoadMetadataForAOTAssembly(dllBytes, mode);
            Debuger.Log($"LoadMetadataForAOTAssembly:{dll}. mode:{mode} ret:{err}");
        }
#if UNITY_EDITOR
        mHotUpdateAssembly = System.AppDomain.CurrentDomain.GetAssemblies().First(a => a.GetName().Name == "HotUpdate"); // Editor下无需加载，直接查找获得HotUpdate程序集
#else
        mHotUpdateAssembly = Assembly.Load(ReadBytesFromStreamingAssets("HotUpdate.dll"));
          Debuger.Log($"LoadHotUpdate.dll Success!");
#endif
    }


}