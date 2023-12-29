/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class com_btn_buy : GButton
    {
        public GLoader _bg;
        public const string URL = "ui://2r331opve9mlkf";

        public static com_btn_buy CreateInstance()
        {
            return (com_btn_buy)UIPackage.CreateObject("CommonPKG", "com_btn_buy");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _bg = (GLoader)GetChild("bg");
        }
    }
}