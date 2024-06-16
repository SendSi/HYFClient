using System;
using System.Collections.Generic;
using GuidePKG;

public class ProxyGuidePKGModule : Singleton<ProxyGuidePKGModule>,IProxy
{
    private const string pkgName = "GuidePKG";
    public void CheckLoad(Action finishCB)
    {
        FGUILoader.Instance.AddPackage(pkgName,finishCB);
    }
    
    
    #region GMMainView打开关闭View

    private GuideMainView _guideView;

    public void OpenGuideMainView(string uiPath)
    {
        if (_guideView == null)
        {        //若有引用 就显示咯 
            CheckLoad(delegate
            {
                _guideView = UIMgr.Instance.OpenUIViewCom<GuideMainView>(pkgName);
                _guideView.SetData(uiPath);
            });
        }
        else
        {
            UIMgr.Instance.ShowUIViewCom<GuideMainView>();
            _guideView.SetData(uiPath);
        }
    }
    
    
    public void OpenGuideMainView(List<GuideStepConfig> stepCfgs)
    {
        if (_guideView == null)
        {        //若有引用 就显示咯 
            CheckLoad(delegate
            {
                _guideView = UIMgr.Instance.OpenUIViewCom<GuideMainView>(pkgName);
                _guideView.SetData(stepCfgs);
            });
        }
        else
        {
            UIMgr.Instance.ShowUIViewCom<GuideMainView>();
            _guideView.SetData(stepCfgs);
        }
    }

    public void HideGuideMainView()
    {
        if (_guideView!=null)
        {
            UIMgr.Instance.HideUIViewCom<GuideMainView>();
        }
    }

    #endregion
    
    
}
