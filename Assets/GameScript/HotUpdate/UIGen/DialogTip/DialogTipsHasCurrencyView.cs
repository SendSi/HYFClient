/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace DialogTip
{
    public partial class DialogTipsHasCurrencyView : GLabel
    {
        public GImage _bg;
        public GList _list;
        public GImage _arrow;
        public GGroup _view;
        public const string URL = "ui://utp01xiasuuv1ygcfeu";

        public static DialogTipsHasCurrencyView CreateInstance()
        {
            return (DialogTipsHasCurrencyView)UIPackage.CreateObject("DialogTip", "DialogTipsHasCurrencyView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _bg = (GImage)GetChild("bg");
            _list = (GList)GetChild("list");
            _arrow = (GImage)GetChild("arrow");
            _view = (GGroup)GetChild("view");
        }
    }
}