/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class showTopTitle_Good : GButton
    {
        public GLoader _bgBig_Left;
        public GLoader _bgBig_Right;
        public GLoader _bgTxt;
        public GLoader _bgSmall_Left;
        public GLoader _bgSmall_Right;
        public GLoader _titleIcon;
        public Transition _tGood;
        public Transition _tFail;
        public const string URL = "ui://2r331opvv6sq1ygcgpx";

        public static showTopTitle_Good CreateInstance()
        {
            return (showTopTitle_Good)UIPackage.CreateObject("CommonPKG", "showTopTitle_Good");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _bgBig_Left = (GLoader)GetChild("bgBig_Left");
            _bgBig_Right = (GLoader)GetChild("bgBig_Right");
            _bgTxt = (GLoader)GetChild("bgTxt");
            _bgSmall_Left = (GLoader)GetChild("bgSmall_Left");
            _bgSmall_Right = (GLoader)GetChild("bgSmall_Right");
            _titleIcon = (GLoader)GetChild("titleIcon");
            _tGood = GetTransition("tGood");
            _tFail = GetTransition("tFail");
        }
    }
}