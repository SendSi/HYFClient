/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ServiceActivity
{
    public partial class daysTaskAward : GComponent
    {
        public GProgressBar _pbr;
        public GList _icon_list;
        public const string URL = "ui://e290e74sho401ygcfly";

        public static daysTaskAward CreateInstance()
        {
            return (daysTaskAward)UIPackage.CreateObject("ServiceActivity", "daysTaskAward");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _pbr = (GProgressBar)GetChild("pbr");
            _icon_list = (GList)GetChild("icon_list");
        }
    }
}