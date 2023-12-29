/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class chiefbtn : GButton
    {
        public Controller _lock;
        public Controller _recommend;
        public GComponent _recommendTxt;
        public GTextField _name;
        public GTextField _lbl;
        public const string URL = "ui://2r331opvqajo1ygcfok";

        public static chiefbtn CreateInstance()
        {
            return (chiefbtn)UIPackage.CreateObject("CommonPKG", "chiefbtn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _lock = GetController("lock");
            _recommend = GetController("recommend");
            _recommendTxt = (GComponent)GetChild("recommendTxt");
            _name = (GTextField)GetChild("name");
            _lbl = (GTextField)GetChild("lbl");
        }
    }
}