/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Login
{
    public partial class tab01 : GComponent
    {
        public Controller _button;
        public Controller _race_bg;
        public GLoader _bg;
        public GLoader _hear;
        public GTextField _title01;
        public GTextField _title02;
        public GTextField _title03;
        public GLoader _select;
        public const string URL = "ui://byy9k3ghgxxt1t";

        public static tab01 CreateInstance()
        {
            return (tab01)UIPackage.CreateObject("Login", "tab01");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _button = GetController("button");
            _race_bg = GetController("race_bg");
            _bg = (GLoader)GetChild("bg");
            _hear = (GLoader)GetChild("hear");
            _title01 = (GTextField)GetChild("title01");
            _title02 = (GTextField)GetChild("title02");
            _title03 = (GTextField)GetChild("title03");
            _select = (GLoader)GetChild("select");
        }
    }
}