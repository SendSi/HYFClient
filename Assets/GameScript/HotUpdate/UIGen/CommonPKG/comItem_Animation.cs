/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class comItem_Animation : GButton
    {
        public Controller _qualityCtrl;
        public comItem _item;
        public GTextField _itemName;
        public Transition _t0;
        public const string URL = "ui://2r331opvp3vgz9clu";

        public static comItem_Animation CreateInstance()
        {
            return (comItem_Animation)UIPackage.CreateObject("CommonPKG", "comItem_Animation");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _qualityCtrl = GetController("qualityCtrl");
            _item = (comItem)GetChild("item");
            _itemName = (GTextField)GetChild("itemName");
            _t0 = GetTransition("t0");
        }
    }
}