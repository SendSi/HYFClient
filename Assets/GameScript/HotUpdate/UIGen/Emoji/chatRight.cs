/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Emoji
{
    public partial class chatRight : GButton
    {
        public GRichTextField _msg;
        public const string URL = "ui://y768eypakfcb1j";

        public static chatRight CreateInstance()
        {
            return (chatRight)UIPackage.CreateObject("Emoji", "chatRight");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _msg = (GRichTextField)GetChild("msg");
        }
    }
}