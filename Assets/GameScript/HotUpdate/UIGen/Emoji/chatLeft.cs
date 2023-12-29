/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Emoji
{
    public partial class chatLeft : GButton
    {
        public GRichTextField _msg;
        public GTextField _name;
        public const string URL = "ui://y768eypakfcb1h";

        public static chatLeft CreateInstance()
        {
            return (chatLeft)UIPackage.CreateObject("Emoji", "chatLeft");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _msg = (GRichTextField)GetChild("msg");
            _name = (GTextField)GetChild("name");
        }
    }
}