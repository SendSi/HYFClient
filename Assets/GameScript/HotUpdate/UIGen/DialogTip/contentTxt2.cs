/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace DialogTip
{
    public partial class contentTxt2 : GComponent
    {
        public GRichTextField _contentTxt;
        public GList _list;
        public const string URL = "ui://utp01xiaff111ygcft2";

        public static contentTxt2 CreateInstance()
        {
            return (contentTxt2)UIPackage.CreateObject("DialogTip", "contentTxt2");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _contentTxt = (GRichTextField)GetChild("contentTxt");
            _list = (GList)GetChild("list");
        }
    }
}