/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace DialogTip
{
    public partial class dropItem : GComponent
    {
        public GLoader _icon;
        public GRichTextField _text;
        public const string URL = "ui://utp01xialbxx3c";

        public static dropItem CreateInstance()
        {
            return (dropItem)UIPackage.CreateObject("DialogTip", "dropItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _icon = (GLoader)GetChild("icon");
            _text = (GRichTextField)GetChild("text");
        }
    }
}