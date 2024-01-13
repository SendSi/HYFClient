using System;
using System.Collections.Generic;
using FairyGUI;
using UnityEngine;
using YooAsset;

public class EffectLoader : Singleton<EffectLoader>
{
    private List<EffectObject> mEffectObjs = new List<EffectObject>();

    /// <summary>普通  加载特效 </summary>
    /// <param name="isAutoDispose">特效 播放完毕后  是否自动释放     另:需要重复播放的,就得设置false,记得得释放</param>
    /// <param name="actionCB">返回一个特效  EffectObject</param>
    public void LoadUIEffect(string effName, GComponent parent, bool isAutoDispose, Action<EffectObject> actionCB = null, float posX = 0f, float posY = 0f, float sizeX = 1f, float sizeY = 1f)
    {
        var handle = YooAssets.LoadAssetAsync<GameObject>(effName);
        handle.Completed += (AssetHandle actGO) =>
        {
            var instGO = actGO.InstantiateSync();
            var eObj = new EffectObject(handle, instGO, parent, isAutoDispose, posX, posY, sizeX, sizeY);
            mEffectObjs.Add(eObj);
            actionCB?.Invoke(eObj);
        };
    }

    /// <summary>加载在父物体的 枚举位置  </summary>
    /// <param name="isAutoDispose">特效 播放完毕后  是否自动释放     另:需要重复播放的,就得设置false,记得得释放</param>
    /// <param name="actionCB">返回一个特效  EffectObject</param>
    public void LoadUIEffectEPos(string effName, GComponent parent, bool isAutoDispose, EffectPos ePos = EffectPos.Center, Action<EffectObject> actionCB = null)
    {
        float xValue = 0f; // 初始值
        float yValue = 0f;
        GetPosionXY(ePos, parent, ref xValue, ref xValue);

        LoadUIEffect(effName, parent, isAutoDispose, actionCB, xValue, xValue);
    }

    void GetPosionXY(EffectPos ePos, GComponent parent, ref float x, ref float y)
    {
        if (ePos == EffectPos.LeftTop)
        {
            x = 0;
            y = 0;
        } else if (ePos == EffectPos.LeftBottom)
        {
            x = 0;
            y = parent.height;
        } else if (ePos == EffectPos.RightTop)
        {
            y = 0;
            x = parent.width;
        } else if (ePos == EffectPos.RightBottom)
        {
            x = parent.width;
            y = parent.height;
        } else
        {
            x = parent.width * 0.5f;
            y = parent.height * 0.5f;
        }
    }

    //默认的场景特效 父节点
    private GameObject _sceneEffectRoot;

    public GameObject sceneEffectRoot
    {
        get
        {
            if (_sceneEffectRoot == null)
            {
                _sceneEffectRoot = new GameObject("SceneEffectRoot");
                _sceneEffectRoot.transform.localPosition = Vector3.zero;
                _sceneEffectRoot.transform.localScale = Vector3.one;
                _sceneEffectRoot.transform.localEulerAngles = Vector3.zero;
                GameObject.DontDestroyOnLoad(_sceneEffectRoot);
            }

            return _sceneEffectRoot;
        }
    }

    /// <summary>加载场景特效  </summary>
    /// <param name="isAutoDispose">特效 播放完毕后  是否自动释放     另:需要重复播放的,就得设置false,记得得释放</param>
    /// <param name="actionCB">返回一个特效  EffectObject</param>
    public void LoadSceneEffect(string effName, GameObject parent, bool isAutoDispose, Action<EffectObject> actionCB, Vector3 vPos, Vector3 vScale, Vector3 vRotate)
    {
        if (parent == null)
        {
            parent = sceneEffectRoot;
        }

        var handle = YooAssets.LoadAssetAsync<GameObject>(effName);
        handle.Completed += (AssetHandle actGO) =>
        {
            var instGO = actGO.InstantiateSync();
            var eObj = new EffectObject(handle, instGO, parent, isAutoDispose, vPos, vScale, vRotate);
            mEffectObjs.Add(eObj);
            actionCB?.Invoke(eObj);
        };
    }

    /// <summary>加载场景特效  </summary>
    /// <param name="isAutoDispose">特效 播放完毕后  是否自动释放     另:需要重复播放的,就得设置false,记得得释放</param>
    /// <param name="actionCB">返回一个特效  EffectObject</param>
    public void LoadSceneEffectSimple(string effName, GameObject parent = null, bool isAutoDispose = true, Action<EffectObject> actionCB = null) { LoadSceneEffect(effName, parent, isAutoDispose, actionCB, Vector3.zero, Vector3.one, Vector3.zero); }

    public void Dispose(EffectObject effObj)
    {
        if (effObj != null)
        {
            effObj.Dispose();
            mEffectObjs.Remove(effObj);
        }
    }

    public void Clear()
    {
        foreach (var item in mEffectObjs)
        {
            item.Dispose(); //能用foreach?
        }

        mEffectObjs.Clear();
    }

    public void LoadEffect_Id(string id)
    {
        var cfg = ConfigMgr.Instance.LoadConfigOne<EffectConfig>(id);
        if (cfg != null)
        {
            if (cfg.eType == 1)
            {
                LoadSceneEffectSimple(cfg.yooPath);
            } 
            else
            {
                var topView = ProxyCommonPKGModule.Instance.GetToastView();
                LoadUIEffectEPos(cfg.yooPath, topView, true);
            }
        }
    }
}

public class EffectObject
{
    public AssetHandle handle { get; set; }
    public GameObject instGo { get; set; }
    public GGraph gGraph { get; set; }
    public GComponent ui_Parent { get; set; }
    public GameObject scene_Parent { get; set; }

    public ParticleInstance particleIns { get; set; }

    public EffectObject(AssetHandle tAH, GameObject tGo, GComponent parent, bool isAutoDispose, float posX, float posY, float sizeX, float sizeY)
    {
        handle = tAH;
        instGo = tGo;
        particleIns = instGo.AddComponent<ParticleInstance>();
        ui_Parent = parent;
        gGraph = new GGraph();
        var wrapper = new GoWrapper(tGo);
        gGraph.SetNativeObject(wrapper);
        parent.AddChild(gGraph);
        gGraph.SetXY(posX, posY);
        gGraph.SetSize(sizeX, sizeY);
        if (isAutoDispose)
        {
            SetStartTimer();
        }
    }

    public EffectObject(AssetHandle tAH, GameObject tGo, GameObject parent, bool isAutoDispose, Vector3 vPos, Vector3 vScale, Vector3 vRotate)
    {
        handle = tAH;
        instGo = tGo;
        particleIns = instGo.AddComponent<ParticleInstance>();
        scene_Parent = parent;
        instGo.transform.parent = parent.transform;

        instGo.transform.localPosition = vPos;
        instGo.transform.localScale = vScale;
        instGo.transform.localEulerAngles = vRotate;

        if (isAutoDispose)
        {
            SetStartTimer();
        }
    }

    private void SetStartTimer()
    {
        if (particleIns != null)
        {
            var timeNum = particleIns.CalcLifeTime();
            FairyGUI.Timers.inst.Add(timeNum, 1, DestroyObj);
        }
    }

    private void DestroyObj(object param) { Dispose(); }

    //再次播放
    public void Play()
    {
        if (gGraph != null)
        {
            gGraph.visible = true;
        }

        if (particleIns != null)
        {
            particleIns.Play();
        }
    }

    //再次播放
    public void Stop()
    {
        if (gGraph != null)
        {
            gGraph.visible = false;
        }
    }

    public void Dispose()
    {
        if (handle != null)
        {
            handle.Release();
        }

        if (instGo != null)
        {
            GameObject.Destroy(instGo);
        }

        if (gGraph != null)
        {
            gGraph.Dispose();
        }

        handle = null;
        instGo = null;
        gGraph = null;
    }

    /// <summary>
    /// 放在父物体的中心位置
    /// </summary>
    public void SetPosCenter()
    {
        if (ui_Parent != null && gGraph != null)
        {
            var x = ui_Parent.width * 0.5f;
            var y = ui_Parent.height * 0.5f;
            gGraph.SetXY(x, y);
        }
    }

    /// <summary> UI特效 设置位置 </summary>
    public void SetPosLocal(float x, float y)
    {
        if (gGraph != null)
        {
            gGraph.SetXY(x, y);
        }
    }

    /// <summary> 场景特效 设置位置 </summary>
    public void SetPosLocal(float x, float y, float z)
    {
        if (instGo != null)
        {
            instGo.transform.localPosition = new Vector3(x, y, z);
        }
    }

    /// <summary> 场景特效 设置位置 </summary>
    public void SetPosLocal(Vector3 vPos)
    {
        if (instGo != null)
        {
            instGo.transform.localPosition = vPos;
        }
    }
}

public enum EffectPos
{
    Center = 0, //中心
    LeftTop = 1, //左上角
    RightTop = 2, //右上角
    LeftBottom = 3, //左下角
    RightBottom = 4, //右下角
}