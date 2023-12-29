/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Login
{
    public partial class list_clothes_04 : GComponent
    {
        public Controller _fold;
        public fold _button;
        public list_clothes_00 _list;
        public const string URL = "ui://byy9k3ghtc38q";

        public static list_clothes_04 CreateInstance()
        {
            return (list_clothes_04)UIPackage.CreateObject("Login", "list_clothes_04");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _fold = GetController("fold");
            _button = (fold)GetChild("button");
            _list = (list_clothes_00)GetChild("list");
        }
    }
}