/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace HeroPKG
{
    public partial class HeroInfoView : GComponent
    {
        public GGraph _bg;
        public GTextField _txtName;
        public GButton _closeBtn;
        public GLoader3D _spineIcon;
        public GButton _leftBtn;
        public GButton _rightBtn;
        public const string URL = "ui://ugveqogjntdkap";

        public static HeroInfoView CreateInstance()
        {
            return (HeroInfoView)UIPackage.CreateObject("HeroPKG", "HeroInfoView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _bg = (GGraph)GetChild("bg");
            _txtName = (GTextField)GetChild("txtName");
            _closeBtn = (GButton)GetChild("closeBtn");
            _spineIcon = (GLoader3D)GetChild("spineIcon");
            _leftBtn = (GButton)GetChild("leftBtn");
            _rightBtn = (GButton)GetChild("rightBtn");
        }
    }
}