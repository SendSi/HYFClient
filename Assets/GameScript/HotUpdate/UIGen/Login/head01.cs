/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Login
{
    public partial class head01 : GComponent
    {
        public GLoader _bg;
        public GLoader _head01;
        public const string URL = "ui://byy9k3ghp7811n";

        public static head01 CreateInstance()
        {
            return (head01)UIPackage.CreateObject("Login", "head01");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _bg = (GLoader)GetChild("bg");
            _head01 = (GLoader)GetChild("head01");
        }
    }
}