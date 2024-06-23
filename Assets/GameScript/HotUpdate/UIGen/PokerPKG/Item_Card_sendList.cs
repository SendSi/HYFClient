/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace PokerPKG
{
    public partial class Item_Card_sendList : GComponent
    {
        public Controller _button;
        public GLoader _icon;
        public const string URL = "ui://q3kpafy9totj1ygcgab";

        public static Item_Card_sendList CreateInstance()
        {
            return (Item_Card_sendList)UIPackage.CreateObject("PokerPKG", "Item_Card_sendList");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _button = GetController("button");
            _icon = (GLoader)GetChild("icon");
        }
    }
}