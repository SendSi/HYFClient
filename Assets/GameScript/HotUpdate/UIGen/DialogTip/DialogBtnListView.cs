/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace DialogTip
{
    public partial class DialogBtnListView : GLabel
    {
        public GImage _bg;
        public GImage _arrow;
        public GList _list;
        public GGroup _view;
        public const string URL = "ui://utp01xiajdqkhz9cya";

        public static DialogBtnListView CreateInstance()
        {
            return (DialogBtnListView)UIPackage.CreateObject("DialogTip", "DialogBtnListView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _bg = (GImage)GetChild("bg");
            _arrow = (GImage)GetChild("arrow");
            _list = (GList)GetChild("list");
            _view = (GGroup)GetChild("view");
        }
    }
}