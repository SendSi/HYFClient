/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace DialogTip
{
    public partial class GetWayViewTemp : GLabel
    {
        public Controller _mode;
        public GComponent _mask;
        public GList _list;
        public getPbr _pbr;
        public GButton _closeButton;
        public GGroup _window;
        public const string URL = "ui://utp01xia10xg71iy5bbq";

        public static GetWayViewTemp CreateInstance()
        {
            return (GetWayViewTemp)UIPackage.CreateObject("DialogTip", "GetWayViewTemp");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _mode = GetController("mode");
            _mask = (GComponent)GetChild("mask");
            _list = (GList)GetChild("list");
            _pbr = (getPbr)GetChild("pbr");
            _closeButton = (GButton)GetChild("closeButton");
            _window = (GGroup)GetChild("window");
        }
    }
}