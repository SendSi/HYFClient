/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace MainCenter
{
    public partial class MainBottomBtn : GButton
    {
        public GImage _bottomBg;
        public GComponent _redPoint;
        public const string URL = "ui://4ni413laj4kdhz9cm2";

        public static MainBottomBtn CreateInstance()
        {
            return (MainBottomBtn)UIPackage.CreateObject("MainCenter", "MainBottomBtn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _bottomBg = (GImage)GetChild("bottomBg");
            _redPoint = (GComponent)GetChild("redPoint");
        }
    }
}