/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class Item_BaseProp : GComponent
    {
        public Controller _qualityCtrl;
        public GLoader _qualityIcon;
        public GLoader _propIcon;
        public GTextField _numTxt;
        public GGroup _content;
        public const string URL = "ui://2r331opvlmzq1ygcgrw";

        public static Item_BaseProp CreateInstance()
        {
            return (Item_BaseProp)UIPackage.CreateObject("CommonPKG", "Item_BaseProp");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _qualityCtrl = GetController("qualityCtrl");
            _qualityIcon = (GLoader)GetChild("qualityIcon");
            _propIcon = (GLoader)GetChild("propIcon");
            _numTxt = (GTextField)GetChild("numTxt");
            _content = (GGroup)GetChild("content");
        }
    }
}