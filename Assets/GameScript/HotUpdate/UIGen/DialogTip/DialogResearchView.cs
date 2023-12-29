/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace DialogTip
{
    public partial class DialogResearchView : GLabel
    {
        public GComponent _mask;
        public GButton _btnNext;
        public GButton _showTopTitle;
        public GTextField _tips0;
        public GList _attributeList;
        public GButton _researchBtn;
        public GTextField _lable;
        public Transition _t0;
        public const string URL = "ui://utp01xiadxcu1ygcfe3";

        public static DialogResearchView CreateInstance()
        {
            return (DialogResearchView)UIPackage.CreateObject("DialogTip", "DialogResearchView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _mask = (GComponent)GetChild("mask");
            _btnNext = (GButton)GetChild("btnNext");
            _showTopTitle = (GButton)GetChild("showTopTitle");
            _tips0 = (GTextField)GetChild("tips0");
            _attributeList = (GList)GetChild("attributeList");
            _researchBtn = (GButton)GetChild("researchBtn");
            _lable = (GTextField)GetChild("lable");
            _t0 = GetTransition("t0");
        }
    }
}