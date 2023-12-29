/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Bag
{
    public partial class BagComposeView : GComponent
    {
        public GButton _closeButton;
        public GLabel _frame;
        public GTextField _title2;
        public GButton _btnCut;
        public GSlider _slider;
        public GButton _btnPlus;
        public GButton _btnYes;
        public GTextField _tipsLbl;
        public GList _list;
        public GTextField _tip;
        public const string URL = "ui://b7676vbq9232k";

        public static BagComposeView CreateInstance()
        {
            return (BagComposeView)UIPackage.CreateObject("Bag", "BagComposeView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _closeButton = (GButton)GetChild("closeButton");
            _frame = (GLabel)GetChild("frame");
            _title2 = (GTextField)GetChild("title2");
            _btnCut = (GButton)GetChild("btnCut");
            _slider = (GSlider)GetChild("slider");
            _btnPlus = (GButton)GetChild("btnPlus");
            _btnYes = (GButton)GetChild("btnYes");
            _tipsLbl = (GTextField)GetChild("tipsLbl");
            _list = (GList)GetChild("list");
            _tip = (GTextField)GetChild("tip");
        }
    }
}