/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace DialogTip
{
    public partial class contentTxt : GComponent
    {
        public GRichTextField _contentTxt;
        public const string URL = "ui://utp01xiatbod38";

        public static contentTxt CreateInstance()
        {
            return (contentTxt)UIPackage.CreateObject("DialogTip", "contentTxt");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _contentTxt = (GRichTextField)GetChild("contentTxt");
        }
    }
}