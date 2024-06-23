using FairyGUI;

namespace MainCenter
{
    public partial class MainTopBtn : GButton
    {
        public void SetData(MainUIBtnConfig cfg)
        {
            if (cfg != null)
            {
                this.icon = cfg.iconURL;
                this.title = cfg.titleTxt;
                this.onClick.Set(() => { MainCenterManager.Instance.OnClickFuncBtn(cfg.id);});
            }
        }
    }
}