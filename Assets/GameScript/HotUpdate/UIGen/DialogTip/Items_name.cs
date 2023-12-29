/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace DialogTip
{
    public partial class Items_name : GComponent
    {
        public GGraph _mask;
        public GList _centerList;
        public const string URL = "ui://utp01xiakxkw1ygcft1";

        public static Items_name CreateInstance()
        {
            return (Items_name)UIPackage.CreateObject("DialogTip", "Items_name");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _mask = (GGraph)GetChild("mask");
            _centerList = (GList)GetChild("centerList");
        }
    }
}