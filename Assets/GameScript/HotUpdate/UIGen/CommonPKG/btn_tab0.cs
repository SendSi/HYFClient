/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class btn_tab0 : GButton
    {
        public GImage _sel;
        public RedPoint _redPoint;
        public const string URL = "ui://2r331opve2ps1iy5b99";

        public static btn_tab0 CreateInstance()
        {
            return (btn_tab0)UIPackage.CreateObject("CommonPKG", "btn_tab0");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _sel = (GImage)GetChild("sel");
            _redPoint = (RedPoint)GetChild("redPoint");
        }
    }
}