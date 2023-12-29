/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace DialogTip
{
    public partial class DialogTipsAttributeTip : GComponent
    {
        public GButton _closeButton;
        public GImage _bg;
        public GTextField _txtDescrption;
        public GImage _arrow;
        public const string URL = "ui://utp01xiapam31iy5bhw";

        public static DialogTipsAttributeTip CreateInstance()
        {
            return (DialogTipsAttributeTip)UIPackage.CreateObject("DialogTip", "DialogTipsAttributeTip");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _closeButton = (GButton)GetChild("closeButton");
            _bg = (GImage)GetChild("bg");
            _txtDescrption = (GTextField)GetChild("txtDescrption");
            _arrow = (GImage)GetChild("arrow");
        }
    }
}