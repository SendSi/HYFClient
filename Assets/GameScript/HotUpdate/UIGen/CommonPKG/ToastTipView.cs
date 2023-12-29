/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class ToastTipView : GComponent
    {
        public ToastItem _ToastIem;
        public const string URL = "ui://2r331opvtixj1ygcg9p";

        public static ToastTipView CreateInstance()
        {
            return (ToastTipView)UIPackage.CreateObject("CommonPKG", "ToastTipView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _ToastIem = (ToastItem)GetChild("ToastIem");
        }
    }
}