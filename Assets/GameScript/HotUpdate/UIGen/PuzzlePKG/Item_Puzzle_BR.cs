/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace PuzzlePKG
{
    public partial class Item_Puzzle_BR : GButton
    {
        public GImage _mask;
        public const string URL = "ui://791wrm7sl4pl1ygcgaj";

        public static Item_Puzzle_BR CreateInstance()
        {
            return (Item_Puzzle_BR)UIPackage.CreateObject("PuzzlePKG", "Item_Puzzle_BR");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _mask = (GImage)GetChild("mask");
        }
    }
}