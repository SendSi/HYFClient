/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Login
{
    public partial class ComboBox1_popup : GComponent
    {
        public GList _list;
        public const string URL = "ui://byy9k3ghjrst1ygcga1";

        public static ComboBox1_popup CreateInstance()
        {
            return (ComboBox1_popup)UIPackage.CreateObject("Login", "ComboBox1_popup");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _list = (GList)GetChild("list");
        }
    }
}