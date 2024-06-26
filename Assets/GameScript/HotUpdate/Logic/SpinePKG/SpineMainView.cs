#region << 脚 本 注 释 >>
//作  用:    ProxySpinePKGModule
//作  者:    曾思信
//创建时间:  #CREATETIME#
#endregion
using FairyGUI;

namespace SpinePKG
{
    public partial class SpineMainView : GComponent
    {
        public override void OnInit()
        {
            base.OnInit();
            this._closeBtn.onClick.Set(() => { ProxySpinePKGModule.Instance.CloseSpineMainView(); });
        }

        public void SetData(string cfgId)
        {
        }
    }
}