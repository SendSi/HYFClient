/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class information_name_camp : GButton
    {
        public Controller _quality;
        public GList _list_star;
        public GLoader _icon_camp;
        public GTextField _name;
        public GLoader _quailtyTitle;
        public const string URL = "ui://2r331opvssbdchk";

        public static information_name_camp CreateInstance()
        {
            return (information_name_camp)UIPackage.CreateObject("CommonPKG", "information_name_camp");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _quality = GetController("quality");
            _list_star = (GList)GetChild("list_star");
            _icon_camp = (GLoader)GetChild("icon_camp");
            _name = (GTextField)GetChild("name");
            _quailtyTitle = (GLoader)GetChild("quailtyTitle");
        }
    }
}