/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class ActivityTipView : GLabel
    {
        public GComponent _mask;
        public GButton _closeButton;
        public GTextField _apLbl;
        public GTextField _nameLbl;
        public GTextField _wordLbl07;
        public GTextField _wordLbl01;
        public GList _list01;
        public GTextField _titleLbl;
        public GTextField _titleLbl01;
        public GList _list02;
        public const string URL = "ui://sinorujtklt51iy5bbs";

        public static ActivityTipView CreateInstance()
        {
            return (ActivityTipView)UIPackage.CreateObject("Activity", "ActivityTipView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _mask = (GComponent)GetChild("mask");
            _closeButton = (GButton)GetChild("closeButton");
            _apLbl = (GTextField)GetChild("apLbl");
            _nameLbl = (GTextField)GetChild("nameLbl");
            _wordLbl07 = (GTextField)GetChild("wordLbl07");
            _wordLbl01 = (GTextField)GetChild("wordLbl01");
            _list01 = (GList)GetChild("list01");
            _titleLbl = (GTextField)GetChild("titleLbl");
            _titleLbl01 = (GTextField)GetChild("titleLbl01");
            _list02 = (GList)GetChild("list02");
        }
    }
}