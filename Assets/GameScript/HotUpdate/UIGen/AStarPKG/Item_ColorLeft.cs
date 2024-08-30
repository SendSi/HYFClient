/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace AStarPKG
{
    public partial class Item_ColorLeft : GButton
    {
        public Controller _colorCtrl;
        public GGraph _color;
        public const string URL = "ui://lqtfwinih90b1";

        public static Item_ColorLeft CreateInstance()
        {
            return (Item_ColorLeft)UIPackage.CreateObject("AStarPKG", "Item_ColorLeft");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _colorCtrl = GetController("colorCtrl");
            _color = (GGraph)GetChild("color");
        }
    }
}