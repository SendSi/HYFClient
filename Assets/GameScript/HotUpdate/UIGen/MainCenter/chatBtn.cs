/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace MainCenter
{
    public partial class chatBtn : GButton
    {
        public Controller _red;
        public GButton _red_2;
        public const string URL = "ui://4ni413lar616hz9cmj";

        public static chatBtn CreateInstance()
        {
            return (chatBtn)UIPackage.CreateObject("MainCenter", "chatBtn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _red = GetController("red");
            _red_2 = (GButton)GetChild("red");
        }
    }
}