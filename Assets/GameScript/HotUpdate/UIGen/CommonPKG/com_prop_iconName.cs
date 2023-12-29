/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class com_prop_iconName : GButton
    {
        public Controller _use;
        public GLoader _bg_quality;
        public GLoader _icon_prop;
        public GTextField _title_have_number;
        public GGroup _0_prop;
        public GLoader _gen_bg1;
        public GLoader _gen_icon;
        public GLoader _gen_frame;
        public GLoader _gen_rightTop;
        public GImage _gen_line;
        public GTextField _gen_lv;
        public GLoader _gen_camp;
        public GLoader _gen_armBg;
        public GLoader _gen_armIcon;
        public GList _list_star;
        public GGroup _1_people;
        public GTextField _name;
        public const string URL = "ui://2r331opvrq2jh1";

        public static com_prop_iconName CreateInstance()
        {
            return (com_prop_iconName)UIPackage.CreateObject("CommonPKG", "com_prop_iconName");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _use = GetController("use");
            _bg_quality = (GLoader)GetChild("bg_quality");
            _icon_prop = (GLoader)GetChild("icon_prop");
            _title_have_number = (GTextField)GetChild("title_have_number");
            _0_prop = (GGroup)GetChild("0_prop");
            _gen_bg1 = (GLoader)GetChild("gen_bg1");
            _gen_icon = (GLoader)GetChild("gen_icon");
            _gen_frame = (GLoader)GetChild("gen_frame");
            _gen_rightTop = (GLoader)GetChild("gen_rightTop");
            _gen_line = (GImage)GetChild("gen_line");
            _gen_lv = (GTextField)GetChild("gen_lv");
            _gen_camp = (GLoader)GetChild("gen_camp");
            _gen_armBg = (GLoader)GetChild("gen_armBg");
            _gen_armIcon = (GLoader)GetChild("gen_armIcon");
            _list_star = (GList)GetChild("list_star");
            _1_people = (GGroup)GetChild("1_people");
            _name = (GTextField)GetChild("name");
        }
    }
}