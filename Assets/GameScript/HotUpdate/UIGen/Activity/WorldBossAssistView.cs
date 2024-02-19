/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class WorldBossAssistView : GLabel
    {
        public GComponent _mask;
        public GComponent _bg;
        public GButton _closeButton;
        public GList _targetList;
        public GTextField _tipte;
        public GGroup _window;
        public Transition _t0;
        public const string URL = "ui://sinorujtgr021ygcfg2";

        public static WorldBossAssistView CreateInstance()
        {
            return (WorldBossAssistView)UIPackage.CreateObject("Activity", "WorldBossAssistView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _mask = (GComponent)GetChild("mask");
            _bg = (GComponent)GetChild("bg");
            _closeButton = (GButton)GetChild("closeButton");
            _targetList = (GList)GetChild("targetList");
            _tipte = (GTextField)GetChild("tipte");
            _window = (GGroup)GetChild("window");
            _t0 = GetTransition("t0");
        }
    }
}