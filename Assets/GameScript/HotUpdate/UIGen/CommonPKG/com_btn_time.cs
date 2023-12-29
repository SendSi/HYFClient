/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class com_btn_time : GButton
    {
        public GTextField _time;
        public const string URL = "ui://2r331opvh55mhz9d1a";

        public static com_btn_time CreateInstance()
        {
            return (com_btn_time)UIPackage.CreateObject("CommonPKG", "com_btn_time");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _time = (GTextField)GetChild("time");
        }
    }
}