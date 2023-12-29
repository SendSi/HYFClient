/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Login
{
    public partial class landItem1 : GComponent
    {
        public GLoader _bg;
        public GTextField _recommend;
        public GLoader _icon;
        public GTextField _num;
        public const string URL = "ui://byy9k3ghcale1ygcg9x";

        public static landItem1 CreateInstance()
        {
            return (landItem1)UIPackage.CreateObject("Login", "landItem1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _bg = (GLoader)GetChild("bg");
            _recommend = (GTextField)GetChild("recommend");
            _icon = (GLoader)GetChild("icon");
            _num = (GTextField)GetChild("num");
        }
    }
}