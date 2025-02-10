/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace PuzzlePKG
{
    public partial class Item_Puzzle_T1 : GButton
    {
        public GImage _mask;
        public const string URL = "ui://791wrm7sjo4c1ygcgaf";

        public static Item_Puzzle_T1 CreateInstance()
        {
            return (Item_Puzzle_T1)UIPackage.CreateObject("PuzzlePKG", "Item_Puzzle_T1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _mask = (GImage)GetChild("mask");
        }
    }
}