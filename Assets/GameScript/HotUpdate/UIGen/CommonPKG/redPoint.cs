/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class RedPoint : GComponent
    {
        public Controller _showCtrl;
        public GImage _img;
        public GTextField _title;
        public const string URL = "ui://2r331opvpyiyhz9d6l";

        public static RedPoint CreateInstance()
        {
            return (RedPoint)UIPackage.CreateObject("CommonPKG", "RedPoint");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _showCtrl = GetController("showCtrl");
            _img = (GImage)GetChild("img");
            _title = (GTextField)GetChild("title");
        }
    }
}