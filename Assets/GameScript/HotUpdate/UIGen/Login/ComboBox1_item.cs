/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Login
{
    public partial class ComboBox1_item : GButton
    {
        public GLoader _bg;
        public const string URL = "ui://byy9k3ghlsme1ygcga6";

        public static ComboBox1_item CreateInstance()
        {
            return (ComboBox1_item)UIPackage.CreateObject("Login", "ComboBox1_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _bg = (GLoader)GetChild("bg");
        }
    }
}