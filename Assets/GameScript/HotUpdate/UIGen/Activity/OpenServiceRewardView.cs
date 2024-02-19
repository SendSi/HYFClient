/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class OpenServiceRewardView : GLabel
    {
        public GButton _closeButton;
        public GTextField _title_name;
        public GList _list;
        public const string URL = "ui://sinorujtnmhb1ygcfhw";

        public static OpenServiceRewardView CreateInstance()
        {
            return (OpenServiceRewardView)UIPackage.CreateObject("Activity", "OpenServiceRewardView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _closeButton = (GButton)GetChild("closeButton");
            _title_name = (GTextField)GetChild("title_name");
            _list = (GList)GetChild("list");
        }
    }
}