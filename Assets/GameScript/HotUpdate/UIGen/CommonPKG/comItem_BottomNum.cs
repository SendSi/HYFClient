/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class comItem_BottomNum : GComponent
    {
        public Controller _bottomNumCtrl;
        public comItem _comItem;
        public GTextField _hadNumFra;
        public const string URL = "ui://2r331opvo23t1ygcfn2";

        public static comItem_BottomNum CreateInstance()
        {
            return (comItem_BottomNum)UIPackage.CreateObject("CommonPKG", "comItem_BottomNum");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _bottomNumCtrl = GetController("bottomNumCtrl");
            _comItem = (comItem)GetChild("comItem");
            _hadNumFra = (GTextField)GetChild("hadNumFra");
        }
    }
}