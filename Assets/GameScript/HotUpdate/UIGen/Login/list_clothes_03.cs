/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Login
{
    public partial class list_clothes_03 : GComponent
    {
        public GList _list;
        public const string URL = "ui://byy9k3gh7oizo";

        public static list_clothes_03 CreateInstance()
        {
            return (list_clothes_03)UIPackage.CreateObject("Login", "list_clothes_03");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _list = (GList)GetChild("list");
        }
    }
}