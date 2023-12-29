/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class com_btnBubble : GComponent
    {
        public GImage _bg;
        public GTextField _title;
        public Transition _admission;
        public const string URL = "ui://2r331opvmp5s1ygcgq7";

        public static com_btnBubble CreateInstance()
        {
            return (com_btnBubble)UIPackage.CreateObject("CommonPKG", "com_btnBubble");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _bg = (GImage)GetChild("bg");
            _title = (GTextField)GetChild("title");
            _admission = GetTransition("admission");
        }
    }
}