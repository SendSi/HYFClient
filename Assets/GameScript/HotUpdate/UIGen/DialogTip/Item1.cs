/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace DialogTip
{
    public partial class Item1 : GComponent
    {
        public GGraph _mask;
        public GList _centerList;
        public const string URL = "ui://utp01xiag17g1ygcfi2";

        public static Item1 CreateInstance()
        {
            return (Item1)UIPackage.CreateObject("DialogTip", "Item1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _mask = (GGraph)GetChild("mask");
            _centerList = (GList)GetChild("centerList");
        }
    }
}