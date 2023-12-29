/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class equipmentIcon : GButton
    {
        public Controller _quality;
        public Controller _state;
        public Controller _receive;
        public Controller _redpoint;
        public Controller _lock;
        public Controller _topNameCtrl;
        public GGraph _indent;
        public GLoader _bg;
        public GTextField _num;
        public GLoader _marka;
        public GLoader _red;
        public GTextField _topNameTxt;
        public GGroup _topName;
        public const string URL = "ui://2r331opvee2ik0";

        public static equipmentIcon CreateInstance()
        {
            return (equipmentIcon)UIPackage.CreateObject("CommonPKG", "equipmentIcon");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _quality = GetController("quality");
            _state = GetController("state");
            _receive = GetController("receive");
            _redpoint = GetController("redpoint");
            _lock = GetController("lock");
            _topNameCtrl = GetController("topNameCtrl");
            _indent = (GGraph)GetChild("indent");
            _bg = (GLoader)GetChild("bg");
            _num = (GTextField)GetChild("num");
            _marka = (GLoader)GetChild("marka");
            _red = (GLoader)GetChild("red");
            _topNameTxt = (GTextField)GetChild("topNameTxt");
            _topName = (GGroup)GetChild("topName");
        }
    }
}