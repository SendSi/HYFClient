/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Bag
{
    public partial class FightOrderBuyView : GComponent
    {
        public GComponent _mask;
        public GTextField _title;
        public GList _list;
        public warePbr _Pbr;
        public GLoader _icon;
        public GGroup _pbr1;
        public GButton _closeButton;
        public GGroup _window;
        public GComponent _propTopList;
        public const string URL = "ui://b7676vbqsaytl4";

        public static FightOrderBuyView CreateInstance()
        {
            return (FightOrderBuyView)UIPackage.CreateObject("Bag", "FightOrderBuyView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _mask = (GComponent)GetChild("mask");
            _title = (GTextField)GetChild("title");
            _list = (GList)GetChild("list");
            _Pbr = (warePbr)GetChild("Pbr");
            _icon = (GLoader)GetChild("icon");
            _pbr1 = (GGroup)GetChild("pbr1");
            _closeButton = (GButton)GetChild("closeButton");
            _window = (GGroup)GetChild("window");
            _propTopList = (GComponent)GetChild("propTopList");
        }
    }
}