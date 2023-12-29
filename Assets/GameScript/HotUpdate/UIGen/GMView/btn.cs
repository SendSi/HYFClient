/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GMView
{
    public partial class btn : GComponent
    {
        public GGraph _send;
        public const string URL = "ui://21uyefv8h7e55";

        public static btn CreateInstance()
        {
            return (btn)UIPackage.CreateObject("GMView", "btn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _send = (GGraph)GetChild("send");
        }
    }
}