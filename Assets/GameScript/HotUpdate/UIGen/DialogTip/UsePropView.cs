/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace DialogTip
{
    public partial class UsePropView : GLabel
    {
        public GComponent _mask;
        public GButton _window;
        public GTextField _titleTxt;
        public GTextField _title2;
        public GButton _useBtn;
        public GButton _cutBtn;
        public GButton _plusBtn;
        public const string URL = "ui://utp01xiaykww2w";

        public static UsePropView CreateInstance()
        {
            return (UsePropView)UIPackage.CreateObject("DialogTip", "UsePropView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _mask = (GComponent)GetChild("mask");
            _window = (GButton)GetChild("window");
            _titleTxt = (GTextField)GetChild("titleTxt");
            _title2 = (GTextField)GetChild("title2");
            _useBtn = (GButton)GetChild("useBtn");
            _cutBtn = (GButton)GetChild("cutBtn");
            _plusBtn = (GButton)GetChild("plusBtn");
        }
    }
}