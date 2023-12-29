/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class sort : GComponent
    {
        public Controller _c1;
        public GImage _bg_01;
        public GImage _bg_02;
        public GImage _bg_03;
        public GImage _bg_04;
        public const string URL = "ui://2r331opvlhtp5";

        public static sort CreateInstance()
        {
            return (sort)UIPackage.CreateObject("CommonPKG", "sort");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _c1 = GetController("c1");
            _bg_01 = (GImage)GetChild("bg_01");
            _bg_02 = (GImage)GetChild("bg_02");
            _bg_03 = (GImage)GetChild("bg_03");
            _bg_04 = (GImage)GetChild("bg_04");
        }
    }
}