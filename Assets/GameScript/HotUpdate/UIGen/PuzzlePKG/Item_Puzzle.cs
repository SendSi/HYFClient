/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace PuzzlePKG
{
    public partial class Item_Puzzle : GButton
    {
        public GLoader _mask;
        public const string URL = "ui://791wrm7st16b1ygcgac";

        public static Item_Puzzle CreateInstance()
        {
            return (Item_Puzzle)UIPackage.CreateObject("PuzzlePKG", "Item_Puzzle");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _mask = (GLoader)GetChild("mask");
        }
    }
}