/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GuidePKG
{
    public partial class guideDesc22 : GComponent
    {
        public GLoader _bgIcon;
        public GTextField _txtContent;
        public GGroup _content;
        public Transition _t0;
        public const string URL = "ui://vypq82a1hsvl3b";

        public static guideDesc22 CreateInstance()
        {
            return (guideDesc22)UIPackage.CreateObject("GuidePKG", "guideDesc22");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _bgIcon = (GLoader)GetChild("bgIcon");
            _txtContent = (GTextField)GetChild("txtContent");
            _content = (GGroup)GetChild("content");
            _t0 = GetTransition("t0");
        }
    }
}