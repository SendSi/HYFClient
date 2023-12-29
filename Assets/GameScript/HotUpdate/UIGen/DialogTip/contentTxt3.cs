/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace DialogTip
{
    public partial class contentTxt3 : GComponent
    {
        public Controller _state;
        public GRichTextField _contentTxt;
        public GLoader _icon;
        public const string URL = "ui://utp01xiaff111ygcft3";

        public static contentTxt3 CreateInstance()
        {
            return (contentTxt3)UIPackage.CreateObject("DialogTip", "contentTxt3");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _state = GetController("state");
            _contentTxt = (GRichTextField)GetChild("contentTxt");
            _icon = (GLoader)GetChild("icon");
        }
    }
}