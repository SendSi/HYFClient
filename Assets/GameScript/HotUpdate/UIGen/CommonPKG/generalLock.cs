/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class generalLock : GButton
    {
        public Controller _state;
        public Controller _quality;
        public Controller _guard;
        public Controller _showBlood;
        public GLoader _bg0;
        public GLoader _bg_black;
        public GLoader _bg;
        public GImage _select;
        public GLoader _add;
        public GLoader _lock;
        public GTextField _iInaccessible;
        public GTextField _notInCity;
        public troopBloodPbr _bloodPbr;
        public const string URL = "ui://2r331opvh00fhz9d46";

        public static generalLock CreateInstance()
        {
            return (generalLock)UIPackage.CreateObject("CommonPKG", "generalLock");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _state = GetController("state");
            _quality = GetController("quality");
            _guard = GetController("guard");
            _showBlood = GetController("showBlood");
            _bg0 = (GLoader)GetChild("bg0");
            _bg_black = (GLoader)GetChild("bg_black");
            _bg = (GLoader)GetChild("bg");
            _select = (GImage)GetChild("select");
            _add = (GLoader)GetChild("add");
            _lock = (GLoader)GetChild("lock");
            _iInaccessible = (GTextField)GetChild("iInaccessible");
            _notInCity = (GTextField)GetChild("notInCity");
            _bloodPbr = (troopBloodPbr)GetChild("bloodPbr");
        }
    }
}