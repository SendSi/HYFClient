/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace MainCenter
{
    public partial class main_btn : GButton
    {
        public GImage _bottomBg;
        public GButton _redPoint;
        public const string URL = "ui://4ni413laj4kdhz9cm2";

        public static main_btn CreateInstance()
        {
            return (main_btn)UIPackage.CreateObject("MainCenter", "main_btn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _bottomBg = (GImage)GetChild("bottomBg");
            _redPoint = (GButton)GetChild("redPoint");
        }
    }
}