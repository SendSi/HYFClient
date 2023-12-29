/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace DialogTip
{
    public partial class attribute001 : GComponent
    {
        public GImage _bg;
        public GRichTextField _title;
        public Transition _t0;
        public Transition _t1;
        public const string URL = "ui://utp01xiantk51ygcfi0";

        public static attribute001 CreateInstance()
        {
            return (attribute001)UIPackage.CreateObject("DialogTip", "attribute001");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _bg = (GImage)GetChild("bg");
            _title = (GRichTextField)GetChild("title");
            _t0 = GetTransition("t0");
            _t1 = GetTransition("t1");
        }
    }
}