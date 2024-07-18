using System;
using cfg;
using GuidePKG;

public class ProxyGuidePKGModule : Singleton<ProxyGuidePKGModule>, IProxy
{
    private const string pkgName = "GuidePKG";

    public void CheckLoad(Action finishCB)
    {
        FGUILoader.Instance.AddPackage(pkgName, finishCB);
    }

    #region GuideMainView打开关闭View

    private GuideMainView _guideView;

    public void OpenGuideMainView(GuideStepConfig stepCfg)
    {
        if (_guideView == null)
        {
            //若有引用 就显示咯 
            CheckLoad(delegate
            {
                _guideView = UIMgr.Instance.OpenUIViewCom<GuideMainView>(pkgName);
                _guideView.SetData(stepCfg);
            });
        }
        else
        {
            _guideView.visible = true;
            _guideView.SetData(stepCfg);
        }
    }

    public void HideGuideMainView()
    {
        if (_guideView != null)
        {
            UIMgr.Instance.HideUIViewCom<GuideMainView>();
        }
    }

    #endregion

    
    
    public void TestLoadView()
    { //若有引用 就显示咯 
            CheckLoad(delegate {  UIMgr.Instance.OpenUIViewCom<guideMask21>(pkgName); });
    }
}