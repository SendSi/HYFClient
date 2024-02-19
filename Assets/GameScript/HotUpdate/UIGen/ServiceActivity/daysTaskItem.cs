/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ServiceActivity
{
    public partial class daysTaskItem : GComponent
    {
        public daysTaskItem1 _item1;
        public Transition _admission;
        public Transition _quit;
        public const string URL = "ui://e290e74sho401ygcfjr";

        public static daysTaskItem CreateInstance()
        {
            return (daysTaskItem)UIPackage.CreateObject("ServiceActivity", "daysTaskItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _item1 = (daysTaskItem1)GetChild("item1");
            _admission = GetTransition("admission");
            _quit = GetTransition("quit");
        }
    }
}