/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ServiceActivity
{
    public partial class MonthCardlabel1 : GComponent
    {
        public Controller _state;
        public GLoader _icon;
        public const string URL = "ui://e290e74srrq31ygcfps";

        public static MonthCardlabel1 CreateInstance()
        {
            return (MonthCardlabel1)UIPackage.CreateObject("ServiceActivity", "MonthCardlabel1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _state = GetController("state");
            _icon = (GLoader)GetChild("icon");
        }
    }
}