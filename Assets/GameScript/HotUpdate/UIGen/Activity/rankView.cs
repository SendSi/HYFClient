/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class rankView : GComponent
    {
        public GImage _arrow;
        public GImage _bg;
        public GList _troopList;
        public const string URL = "ui://sinorujtw2ss1ygcfgb";

        public static rankView CreateInstance()
        {
            return (rankView)UIPackage.CreateObject("Activity", "rankView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _arrow = (GImage)GetChild("arrow");
            _bg = (GImage)GetChild("bg");
            _troopList = (GList)GetChild("troopList");
        }
    }
}