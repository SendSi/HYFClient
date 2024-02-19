/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ServiceActivity
{
    public partial class taskTypeItem : GButton
    {
        public Controller _reddot;
        public GLoader _red;
        public const string URL = "ui://e290e74sho401ygcfjq";

        public static taskTypeItem CreateInstance()
        {
            return (taskTypeItem)UIPackage.CreateObject("ServiceActivity", "taskTypeItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _reddot = GetController("reddot");
            _red = (GLoader)GetChild("red");
        }
    }
}