/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class comItem3 : GButton
    {
        public Controller _qualityCtrl;
        public GLoader _bg;
        public GTextField _num;
        public const string URL = "ui://2r331opvps611ygcgqy";

        public static comItem3 CreateInstance()
        {
            return (comItem3)UIPackage.CreateObject("CommonPKG", "comItem3");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _qualityCtrl = GetController("qualityCtrl");
            _bg = (GLoader)GetChild("bg");
            _num = (GTextField)GetChild("num");
        }
    }
}