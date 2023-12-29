/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace DialogTip
{
    public partial class GetWayItemTemp : GComponent
    {
        public GImage _propBg;
        public GLoader _icon;
        public GGroup _propIcon;
        public GButton _useBtn;
        public GGroup _use;
        public GTextField _title;
        public GTextField _desc;
        public const string URL = "ui://utp01xia10xg71iy5bbt";

        public static GetWayItemTemp CreateInstance()
        {
            return (GetWayItemTemp)UIPackage.CreateObject("DialogTip", "GetWayItemTemp");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _propBg = (GImage)GetChild("propBg");
            _icon = (GLoader)GetChild("icon");
            _propIcon = (GGroup)GetChild("propIcon");
            _useBtn = (GButton)GetChild("useBtn");
            _use = (GGroup)GetChild("use");
            _title = (GTextField)GetChild("title");
            _desc = (GTextField)GetChild("desc");
        }
    }
}