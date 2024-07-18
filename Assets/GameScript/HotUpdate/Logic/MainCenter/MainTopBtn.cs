using FairyGUI;
using cfg;
namespace MainCenter
{
    public partial class MainTopBtn : GButton
    {
        public void SetData(MainUIBtnConfig cfg)
        {
            if (cfg != null)
            {
                this.icon = cfg.IconURL;
                this.title = cfg.TitleTxt;
                this.onClick.Set(() => { MainCenterManager.Instance.OnClickFuncBtn(cfg.Id);});
            }
        }
    }
}