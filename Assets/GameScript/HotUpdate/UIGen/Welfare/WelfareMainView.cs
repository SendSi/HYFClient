/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Welfare
{
    public partial class WelfareMainView : GComponent
    {
        public GLoader _bg;
        public GLoader _conPanel;
        public GList _leftTabList;
        public GButton _closeButton;
        public GGroup _Left;
        public Transition _t0;
        public const string URL = "ui://340eighfmqls1ygcfi7";

        public static WelfareMainView CreateInstance()
        {
            return (WelfareMainView)UIPackage.CreateObject("Welfare", "WelfareMainView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _bg = (GLoader)GetChild("bg");
            _conPanel = (GLoader)GetChild("conPanel");
            _leftTabList = (GList)GetChild("leftTabList");
            _closeButton = (GButton)GetChild("closeButton");
            _Left = (GGroup)GetChild("Left");
            _t0 = GetTransition("t0");
        }
    }
}