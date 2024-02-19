/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class SeasonRecruitPreviewView : GLabel
    {
        public GComponent _mask;
        public GTextField _titleTxt02;
        public GList _cardList;
        public GButton _closeButton;
        public GGroup _windows;
        public const string URL = "ui://sinorujtgo3t1ygcfmi";

        public static SeasonRecruitPreviewView CreateInstance()
        {
            return (SeasonRecruitPreviewView)UIPackage.CreateObject("Activity", "SeasonRecruitPreviewView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _mask = (GComponent)GetChild("mask");
            _titleTxt02 = (GTextField)GetChild("titleTxt02");
            _cardList = (GList)GetChild("cardList");
            _closeButton = (GButton)GetChild("closeButton");
            _windows = (GGroup)GetChild("windows");
        }
    }
}