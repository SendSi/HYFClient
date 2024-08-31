/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace AStarPKG
{
    public partial class Item_Cell : GComponent
    {
        public Controller _colorCtrl;
        public GGraph _color;
        public GRichTextField _title;
        public const string URL = "ui://lqtfwinih90b2";

        public static Item_Cell CreateInstance()
        {
            return (Item_Cell)UIPackage.CreateObject("AStarPKG", "Item_Cell");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _colorCtrl = GetController("colorCtrl");
            _color = (GGraph)GetChild("color");
            _title = (GRichTextField)GetChild("title");
        }
    }
}