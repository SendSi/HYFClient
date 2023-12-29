/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Login
{
    public partial class clothes_btn : GButton
    {
        public GTextField _title_name;
        public GTextField _title_number;
        public const string URL = "ui://byy9k3ghp7811e";

        public static clothes_btn CreateInstance()
        {
            return (clothes_btn)UIPackage.CreateObject("Login", "clothes_btn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _title_name = (GTextField)GetChild("title_name");
            _title_number = (GTextField)GetChild("title_number");
        }
    }
}