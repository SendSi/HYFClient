/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Welfare
{
    public partial class LimitShop_item2 : GComponent
    {
        public Controller _fresh;
        public GTextField _name;
        public GButton _openBtn;
        public GButton _receivedBtn;
        public GButton _receiveBtn;
        public GButton _freshBtn;
        public GTextField _title;
        public GLoader _icon;
        public const string URL = "ui://340eighfcmbv1ygcfji";

        public static LimitShop_item2 CreateInstance()
        {
            return (LimitShop_item2)UIPackage.CreateObject("Welfare", "LimitShop_item2");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _fresh = GetController("fresh");
            _name = (GTextField)GetChild("name");
            _openBtn = (GButton)GetChild("openBtn");
            _receivedBtn = (GButton)GetChild("receivedBtn");
            _receiveBtn = (GButton)GetChild("receiveBtn");
            _freshBtn = (GButton)GetChild("freshBtn");
            _title = (GTextField)GetChild("title");
            _icon = (GLoader)GetChild("icon");
        }
    }
}