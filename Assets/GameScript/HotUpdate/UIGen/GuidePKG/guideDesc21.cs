/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GuidePKG
{
    public partial class guideDesc21 : GComponent
    {
        public GLoader _bgIcon;
        public GTextField _txtContent;
        public GTextField _txtNext;
        public GGroup _content;
        public Transition _t0;
        public const string URL = "ui://vypq82a1gyzy8";

        public static guideDesc21 CreateInstance()
        {
            return (guideDesc21)UIPackage.CreateObject("GuidePKG", "guideDesc21");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _bgIcon = (GLoader)GetChild("bgIcon");
            _txtContent = (GTextField)GetChild("txtContent");
            _txtNext = (GTextField)GetChild("txtNext");
            _content = (GGroup)GetChild("content");
            _t0 = GetTransition("t0");
        }
    }
}