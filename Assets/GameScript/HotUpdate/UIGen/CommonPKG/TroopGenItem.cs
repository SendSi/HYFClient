/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class TroopGenItem : GButton
    {
        public Controller _quality;
        public GLoader _bg_quality00;
        public troopGeneralIcon _general;
        public GImage _bg02;
        public GTextField _title_grade;
        public GImage _bg03;
        public GList _list_star;
        public GTextField _starLevel;
        public const string URL = "ui://2r331opv9itdz9cnx";

        public static TroopGenItem CreateInstance()
        {
            return (TroopGenItem)UIPackage.CreateObject("CommonPKG", "TroopGenItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _quality = GetController("quality");
            _bg_quality00 = (GLoader)GetChild("bg_quality00");
            _general = (troopGeneralIcon)GetChild("general");
            _bg02 = (GImage)GetChild("bg02");
            _title_grade = (GTextField)GetChild("title_grade");
            _bg03 = (GImage)GetChild("bg03");
            _list_star = (GList)GetChild("list_star");
            _starLevel = (GTextField)GetChild("starLevel");
        }
    }
}