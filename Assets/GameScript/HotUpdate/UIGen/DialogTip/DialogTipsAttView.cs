/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace DialogTip
{
    public partial class DialogTipsAttView : GLabel
    {
        public GList _rule_list;
        public GButton _closeButton;
        public GTextField _titleTxt;
        public GGroup _activity;
        public const string URL = "ui://utp01xiaesvr1iy5bbo";

        public static DialogTipsAttView CreateInstance()
        {
            return (DialogTipsAttView)UIPackage.CreateObject("DialogTip", "DialogTipsAttView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _rule_list = (GList)GetChild("rule_list");
            _closeButton = (GButton)GetChild("closeButton");
            _titleTxt = (GTextField)GetChild("titleTxt");
            _activity = (GGroup)GetChild("activity");
        }
    }
}