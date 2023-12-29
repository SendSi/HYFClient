/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class showTopTitle01 : GButton
    {
        public GLoader _bgBig_Left;
        public GLoader _bgBig_Right;
        public GLoader _bgTxt;
        public GLoader _bgLeft_small;
        public GLoader _bgRight_big;
        public GLoader _titleIcon;
        public Transition _tFail;
        public const string URL = "ui://2r331opvrpi01ygcgpt";

        public static showTopTitle01 CreateInstance()
        {
            return (showTopTitle01)UIPackage.CreateObject("CommonPKG", "showTopTitle01");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _bgBig_Left = (GLoader)GetChild("bgBig_Left");
            _bgBig_Right = (GLoader)GetChild("bgBig_Right");
            _bgTxt = (GLoader)GetChild("bgTxt");
            _bgLeft_small = (GLoader)GetChild("bgLeft_small");
            _bgRight_big = (GLoader)GetChild("bgRight_big");
            _titleIcon = (GLoader)GetChild("titleIcon");
            _tFail = GetTransition("tFail");
        }
    }
}