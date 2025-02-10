/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace PuzzlePKG
{
    public partial class PuzzleMainView_bak : GComponent
    {
        public GButton _closeButton;
        public GLoader _iconBg;
        public GList _itemList;
        public GButton _btnGoto;
        public const string URL = "ui://791wrm7st16bf";

        public static PuzzleMainView_bak CreateInstance()
        {
            return (PuzzleMainView_bak)UIPackage.CreateObject("PuzzlePKG", "PuzzleMainView_bak");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _closeButton = (GButton)GetChild("closeButton");
            _iconBg = (GLoader)GetChild("iconBg");
            _itemList = (GList)GetChild("itemList");
            _btnGoto = (GButton)GetChild("btnGoto");
        }
    }
}