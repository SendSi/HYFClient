/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class com_item_upgrade1 : GComponent
    {
        public Controller _state;
        public GLoader _buildIcon;
        public GImage _bg;
        public GRichTextField _title;
        public GRichTextField _title2;
        public com_btn_tab3 _newbuildBtn;
        public const string URL = "ui://2r331opv91o91ygcfkt";

        public static com_item_upgrade1 CreateInstance()
        {
            return (com_item_upgrade1)UIPackage.CreateObject("CommonPKG", "com_item_upgrade1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _state = GetController("state");
            _buildIcon = (GLoader)GetChild("buildIcon");
            _bg = (GImage)GetChild("bg");
            _title = (GRichTextField)GetChild("title");
            _title2 = (GRichTextField)GetChild("title2");
            _newbuildBtn = (com_btn_tab3)GetChild("newbuildBtn");
        }
    }
}