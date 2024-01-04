
    using System;

    public class ProxyMainRoleModule:Singleton<ProxyMainRoleModule>,IProxy
    {
        private const string pkgName = "MainRole";
        public void CheckLoad(Action finishCB)
        {
            FGUILoader.Instance.AddPackage(pkgName,finishCB);
        }


        #region RoleMainView打开关闭Window

        public void OpenRoleMainViewWin()
        {
            CheckLoad(() => { UIMgr.Instance.OpenWindow<RoleMainViewWin>(); });
        }

        public void CloseRoleMainViewWin()
        {
            UIMgr.Instance.CloseWindow<RoleMainViewWin>();
        }

        #endregion

    }
