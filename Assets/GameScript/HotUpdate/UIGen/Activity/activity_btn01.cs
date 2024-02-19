/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class activity_btn01 : GButton
    {
        public Controller _lock;
        public Controller _recommend;
        public GTextField _name;
        public GComponent _recommendTxt;
        public const string URL = "ui://sinorujts4xx1ygcfol";

        public static activity_btn01 CreateInstance()
        {
            return (activity_btn01)UIPackage.CreateObject("Activity", "activity_btn01");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _lock = GetController("lock");
            _recommend = GetController("recommend");
            _name = (GTextField)GetChild("name");
            _recommendTxt = (GComponent)GetChild("recommendTxt");
        }
    }
}