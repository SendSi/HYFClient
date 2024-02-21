/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Welfare
{
    public partial class Child_DiamondView : GComponent
    {
        public GImage _topIcon;
        public GProgressBar _curProSlider;
        public GButton _goWarBtn;
        public GTextField _descTxt;
        public GTextField _gradeLbl;
        public GTextField _titleTxt;
        public GList _diamondList;
        public const string URL = "ui://340eighf9sqn1ygcfib";

        public static Child_DiamondView CreateInstance()
        {
            return (Child_DiamondView)UIPackage.CreateObject("Welfare", "Child_DiamondView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _topIcon = (GImage)GetChild("topIcon");
            _curProSlider = (GProgressBar)GetChild("curProSlider");
            _goWarBtn = (GButton)GetChild("goWarBtn");
            _descTxt = (GTextField)GetChild("descTxt");
            _gradeLbl = (GTextField)GetChild("gradeLbl");
            _titleTxt = (GTextField)GetChild("titleTxt");
            _diamondList = (GList)GetChild("diamondList");
        }
    }
}