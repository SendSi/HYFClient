/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Login
{
    public partial class ServerListRemoteView : GComponent
    {
        public GComponent _mask;
        public GLabel _frame;
        public GTextField _coords;
        public GGroup _view1;
        public const string URL = "ui://byy9k3ghqg411ygcg9q";

        public static ServerListRemoteView CreateInstance()
        {
            return (ServerListRemoteView)UIPackage.CreateObject("Login", "ServerListRemoteView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _mask = (GComponent)GetChild("mask");
            _frame = (GLabel)GetChild("frame");
            _coords = (GTextField)GetChild("coords");
            _view1 = (GGroup)GetChild("view1");
        }
    }
}