using FairyGUI;
using UnityEngine;

namespace MainCenter
{
    public partial class main_btn : GButton
    {
        public void SetData(FuncBtnData data)
        {
            if (data != null)
            {
                this.icon = data._iconURL;
                this.title = data._titleTxt;
                this.onClick.Set(() =>
                {
                    data._clikcAct?.Invoke();
                });
            }
            this._redPoint.GetController("showCtrl").selectedIndex = Random.Range(0, 3);//红点随机
        }
    }
}
