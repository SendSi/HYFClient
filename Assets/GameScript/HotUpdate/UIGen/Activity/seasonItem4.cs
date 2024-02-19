/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class seasonItem4 : GComponent
    {
        public Controller _button;
        public GTextField _title;
        public GTextField _level;
        public GTextField _name;
        public const string URL = "ui://sinorujtx5ob1ygcfmc";

        public static seasonItem4 CreateInstance()
        {
            return (seasonItem4)UIPackage.CreateObject("Activity", "seasonItem4");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _button = GetController("button");
            _title = (GTextField)GetChild("title");
            _level = (GTextField)GetChild("level");
            _name = (GTextField)GetChild("name");
        }
    }
}