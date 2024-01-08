/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace MainCenter
{
    public partial class Main_btn : GButton
    {
        public GImage _bottomBg;
        public GComponent _redPoint;
        public const string URL = "ui://4ni413laj4kdhz9cm2";

        public static Main_btn CreateInstance()
        {
            return (Main_btn)UIPackage.CreateObject("MainCenter", "Main_btn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _bottomBg = (GImage)GetChild("bottomBg");
            _redPoint = (GComponent)GetChild("redPoint");
        }
    }
}