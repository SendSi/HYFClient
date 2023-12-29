
    using System;

    public class ProxyMainRoleModule:BaseInstance<ProxyMainRoleModule>,IProxy
    {
        private const string pkgName = "MainRole";
        public void CheckLoad(Action finishCB)
        {
            FGUILoader.GetInstance().AddPackage(pkgName,finishCB);
        }


        #region RoleMainView打开关闭Window

        public void OpenRoleMainViewWin()
        {
            CheckLoad(() => { UIMgr.GetInstance().OpenWindow<RoleMainViewWin>(); });
        }

        public void CloseRoleMainViewWin()
        {
            UIMgr.GetInstance().CloseWindow<RoleMainViewWin>();
        }

        #endregion

    }
