/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Login
{
    public partial class list_clothes_01 : GComponent
    {
        public GTextField _title;
        public GList _list;
        public const string URL = "ui://byy9k3gh7oizm";

        public static list_clothes_01 CreateInstance()
        {
            return (list_clothes_01)UIPackage.CreateObject("Login", "list_clothes_01");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _title = (GTextField)GetChild("title");
            _list = (GList)GetChild("list");
        }
    }
}