/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace DialogTip
{
    public partial class FloatTipView : GComponent
    {
        public GComponent _TipItem;
        public const string URL = "ui://utp01xiaq1qg1";

        public static FloatTipView CreateInstance()
        {
            return (FloatTipView)UIPackage.CreateObject("DialogTip", "FloatTipView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _TipItem = (GComponent)GetChild("TipItem");
        }
    }
}