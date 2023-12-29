/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace MainCenter
{
    public partial class buildQueueBtn : GButton
    {
        public Controller _buildState;
        public Controller _showText;
        public GImage _bg;
        public Transition _t1;
        public Transition _t2;
        public const string URL = "ui://4ni413layya01qp8vcb";

        public static buildQueueBtn CreateInstance()
        {
            return (buildQueueBtn)UIPackage.CreateObject("MainCenter", "buildQueueBtn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _buildState = GetController("buildState");
            _showText = GetController("showText");
            _bg = (GImage)GetChild("bg");
            _t1 = GetTransition("t1");
            _t2 = GetTransition("t2");
        }
    }
}