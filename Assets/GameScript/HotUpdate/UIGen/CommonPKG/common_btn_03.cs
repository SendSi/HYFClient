/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class common_btn_03 : GButton
    {
        public Controller _state;
        public red_dot _red;
        public const string URL = "ui://2r331opv9232ex";

        public static common_btn_03 CreateInstance()
        {
            return (common_btn_03)UIPackage.CreateObject("CommonPKG", "common_btn_03");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _state = GetController("state");
            _red = (red_dot)GetChild("red");
        }
    }
}