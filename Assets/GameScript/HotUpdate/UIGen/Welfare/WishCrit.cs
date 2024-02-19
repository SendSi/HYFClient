/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Welfare
{
    public partial class WishCrit : GComponent
    {
        public GTextField _title;
        public GGroup _number;
        public const string URL = "ui://340eighfvsu61ygcfoc";

        public static WishCrit CreateInstance()
        {
            return (WishCrit)UIPackage.CreateObject("Welfare", "WishCrit");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _title = (GTextField)GetChild("title");
            _number = (GGroup)GetChild("number");
        }
    }
}