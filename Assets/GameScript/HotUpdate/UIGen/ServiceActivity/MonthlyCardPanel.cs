/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ServiceActivity
{
    public partial class MonthlyCardPanel : GLabel
    {
        public GLoader _bg;
        public GList _cardList;
        public GButton _btnExplain;
        public GGroup _windows;
        public Transition _t0;
        public const string URL = "ui://e290e74se8ok1ygcfph";

        public static MonthlyCardPanel CreateInstance()
        {
            return (MonthlyCardPanel)UIPackage.CreateObject("ServiceActivity", "MonthlyCardPanel");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _bg = (GLoader)GetChild("bg");
            _cardList = (GList)GetChild("cardList");
            _btnExplain = (GButton)GetChild("btnExplain");
            _windows = (GGroup)GetChild("windows");
            _t0 = GetTransition("t0");
        }
    }
}