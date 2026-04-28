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
    [Header("=== PlayMode:在UnityEditor下，这个可说是不生效的(若要生效或测热更，请看Start方法)。")]  // 给字段组加标题
    [Header("在出包状态下，则生效，一般是HostPlayMode热更模式,或是OfflinePlayMode离线模式===")]  // 给字段组加标题
    /// <summary> 资源系统运行模式 </summary>
    public EPlayMode PlayMode = EPlayMode.HostPlayMode;

    public static GameMain Instance;

    void Awake()
    {
        Instance = this;
        Debug.Log($"资源系统运行模式：{PlayMode},cdn={AppConfig.hostServerIP}");
        Application.targetFrameRate = 60;
        Application.runInBackground = true;
        DontDestroyOnLoad(this.gameObject);
        Application.lowMemory += OnLowMemory;
    }

    IEnumerator Start()
    {
        // 初始化资源系统
        YooAssets.Initialize();
        Debuger.EnableLog = AppConfig.EnableLog;

        FairyGUI.GRoot.inst.SetContentScaleFactor(AppConfig.designResolutionX, AppConfig.designResolutionY, FairyGUI.UIContentScaler.ScreenMatchMode.MatchHeight); //设计尺寸
        this.gameObject.AddComponent<FairyGUI.SafeAreaUtils>();

#if UNITY_EDITOR//开发时  就是要快一点见到页面  统一使用跳过热更，也就是PlayMode是失效的
        yield return CheckSkipHFView(); //跳过 热更页面    
#else //出包状态下，才会有识别PlayMode的逻辑
        if (PlayMode == EPlayMode.EditorSimulateMode)
        {
            Debug.LogError("EditorSimulateMode 只能在 Unity Editor 中使用！请在 Inspector 上切换为 HostPlayMode 或 OfflinePlayMode");
            yield break;
        }
        else if (PlayMode == EPlayMode.OfflinePlayMode)//离线模式下  跳过热更页面
        {
            yield return CheckOfflineMode(); //离线模式初始化
        }
        else
        {
            yield return CheckLoadYooHF();//HostPlayMode 联机热更模式  和 webGL运行模式下
        }
#endif
        //若每次测的 AppConfig.appVersion = "v1.0"  则HYFClient/yoo目录不会被更新，因为版本号没变，所以不会去下载  已有时,则会判断增涨  所以结论 把HYFClient/yoo目录删除，每次都会去下载
        // yield return CheckLoadYooHF(); //在UnityEditor下 若要测试Host手动改下 上面13行注释掉即可  打开这一行

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
        Application.lowMemory -= OnLowMemory;
    }

    //加载热更页面
    private IEnumerator CheckLoadYooHF()
    {
        ProxyHotPKGModule.Instance.OpenHFView();
        // 开始补丁更新流程
        // PatchOperation operation = new PatchOperation("DefaultPackage", EDefaultBuildPipeline.BuiltinBuildPipeline.ToString(), PlayMode);
        PatchOperation operation = new PatchOperation(AppConfig.defaultYooAssetPKG, EDefaultBuildPipeline.BuiltinBuildPipeline.ToString(), PlayMode);
        YooAssets.StartOperation(operation);
        yield return operation;
        //更新热更代码
        PatchOperation operation_hotFix = new PatchOperation(AppConfig.hotFixPackage, EDefaultBuildPipeline.RawFileBuildPipeline.ToString(), PlayMode);
        YooAssets.StartOperation(operation_hotFix);
        yield return operation_hotFix;

        //加载元数据 和 热更代码
        yield return LoadHotFixRes();
        LoadMetadataForAOTAssemblies();//里面有 mHotUpdateAssembly

        var gamePackage = YooAssets.GetPackage(AppConfig.defaultYooAssetPKG); //"DefaultPackage");
        YooAssets.SetDefaultPackage(gamePackage);
    }

    //跳过热更页面 - 只在 Unity Editor 中使用
    private IEnumerator CheckSkipHFView()
    {
        var package = YooAssets.CreatePackage(AppConfig.defaultYooAssetPKG);
        YooAssets.SetDefaultPackage(package);
        var createParameters = new EditorSimulateModeParameters();
        createParameters.SimulateManifestFilePath = EditorSimulateModeHelper.SimulateBuild(EDefaultBuildPipeline.BuiltinBuildPipeline.ToString(), AppConfig.defaultYooAssetPKG);
        var initializationOperation = package.InitializeAsync(createParameters);
        yield return initializationOperation;
        mHotUpdateAssembly = System.AppDomain.CurrentDomain.GetAssemblies().First(a => a.GetName().Name == "HotUpdate"); // Editor下无需加载，直接查找获得HotUpdate程序集
    }

    //离线模式初始化 - 用于出包后的 OfflinePlayMode
    private IEnumerator CheckOfflineMode()
    {
        ProxyHotPKGModule.Instance.OpenHFView();
        
        // 创建资源包
        var package = YooAssets.CreatePackage(AppConfig.defaultYooAssetPKG);
        YooAssets.SetDefaultPackage(package);
        
        // 使用离线模式参数（从 StreamingAssets 加载）
        var createParameters = new OfflinePlayModeParameters();
        var initializationOperation = package.InitializeAsync(createParameters);
        yield return initializationOperation;
        
        if (initializationOperation.Status != EOperationStatus.Succeed)
        {
            Debug.LogError($"离线模式初始化失败: {initializationOperation.Error}");
            yield break;
        }
        
        
        // 更新热更代码
        var operation_hotFix = new PatchOperation("HotFixPackage", EDefaultBuildPipeline.RawFileBuildPipeline.ToString(), PlayMode);
        YooAssets.StartOperation(operation_hotFix);
        yield return operation_hotFix;
        
        // 加载元数据 和 热更代码
        yield return LoadHotFixRes();
        LoadMetadataForAOTAssemblies();
    }

    private IEnumerator LoadHotFixRes()
    {
        var hotfixPackage = YooAssets.GetPackage(AppConfig.hotFixPackage);
        foreach (var dll in mAssemblyFiles)
        {
            var handle = hotfixPackage.LoadRawFileAsync($"Assets/GameResHotFix/{dll}.bytes");//一起load啦   hotUpdate.dll  hotUpdate.pdb
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

    //AOTGenericReferences.cs     PatchedAOTAssemblyList
    private static List<string> mAssemblyFiles { get; } = new List<string>()
    {
        "AOT.dll",
        "Google.Protobuf.dll",
        "Grpc.Core.Api.dll",
        "Luban.Runtime.dll",
        "Newtonsoft.Json.dll",
        "System.Core.dll",
        "UnityEngine.CoreModule.dll",
        "UnityEngine.JSONSerializeModule.dll",
        "YooAsset.dll",
        "mscorlib.dll",
        "UniTask.dll",

        "HotUpdate.dll", //不需使用 RuntimeApi.LoadMetadataForAOTAssembly(dllBytes, mode);加载
        "HotUpdate.pdb", //pdb 为输入堆栈使用的
    };

    /// <summary>
    /// 为aot assembly加载原始metadata， 这个代码放aot或者热更新都行。
    /// 一旦加载后，如果AOT泛型函数对应native实现不存在，则自动替换为解释模式执行
    /// </summary>
    private static void LoadMetadataForAOTAssemblies()
    {
        // 注意，补充元数据是给AOT dll补充元数据，而不是给热更新dll补充元数据。 热更新dll不缺元数据，不需要补充，如果调用LoadMetadataForAOTAssembly会返回错误
        HomologousImageMode mode = HomologousImageMode.SuperSet;
        for (int i = 0; i < mAssemblyFiles.Count - 2; i++)
        {// 减一 最后一个是HotUpdate.dll  不是aot
            var dll = mAssemblyFiles[i];
            byte[] dllBytes = ReadBytesFromStreamingAssets(dll);
            // 加载assembly对应的dll，会自动为它hook。一旦aot泛型函数的native函数不存在，用解释器版本代码
            LoadImageErrorCode err = RuntimeApi.LoadMetadataForAOTAssembly(dllBytes, mode);
            Debuger.Log($"LoadMetadataForAOTAssembly:{dll}. mode:{mode} ret:{err}");
        }
#if UNITY_EDITOR
        mHotUpdateAssembly = System.AppDomain.CurrentDomain.GetAssemblies().First(a => a.GetName().Name == "HotUpdate"); // Editor下无需加载，直接查找获得HotUpdate程序集
#else
        mHotUpdateAssembly = Assembly.Load(ReadBytesFromStreamingAssets("HotUpdate.dll"),ReadBytesFromStreamingAssets("HotUpdate.pdb"));
        Debug.Log($"Load HotUpdate.dll and HotUpdate.pdb Success!");
#endif


    }


    public void AddLowMemory(Action action)
    {
        _lowMemory += action;
    }
    public void RemoveLowMemory(Action action)
    {
        _lowMemory -= action;
    }
    Action _lowMemory;

    void OnLowMemory()
    {
        _lowMemory?.Invoke();
    }

}