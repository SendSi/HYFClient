using FairyGUI;

namespace MainCenter
{
    public partial class Main_FuncTop : GButton
    {
        public void SetData(FuncBtnData data)
        {
            if (data != null)
            {
                this.icon = data.iconURL;
                this.title = data.titleTxt;
                this.onClick.Set(() => { data.clikcAct?.Invoke(); });
            }
        }
    }
}