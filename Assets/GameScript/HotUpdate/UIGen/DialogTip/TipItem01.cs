/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace DialogTip
{
    public partial class TipItem01 : GComponent
    {
        public GList _list;
        public Transition _moveAlpha;
        public const string URL = "ui://utp01xiantk51ygcfhz";

        public static TipItem01 CreateInstance()
        {
            return (TipItem01)UIPackage.CreateObject("DialogTip", "TipItem01");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _list = (GList)GetChild("list");
            _moveAlpha = GetTransition("moveAlpha");
        }
    }
}