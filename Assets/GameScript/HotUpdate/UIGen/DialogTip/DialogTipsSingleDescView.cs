/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace DialogTip
{
    public partial class DialogTipsSingleDescView : GLabel
    {
        public GImage _bg;
        public GTextField _titleName;
        public GLabel _titleDesc;
        public GImage _arrow;
        public GGroup _view;
        public const string URL = "ui://utp01xiar8ha1ygcftd";

        public static DialogTipsSingleDescView CreateInstance()
        {
            return (DialogTipsSingleDescView)UIPackage.CreateObject("DialogTip", "DialogTipsSingleDescView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _bg = (GImage)GetChild("bg");
            _titleName = (GTextField)GetChild("titleName");
            _titleDesc = (GLabel)GetChild("titleDesc");
            _arrow = (GImage)GetChild("arrow");
            _view = (GGroup)GetChild("view");
        }
    }
}