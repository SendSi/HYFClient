/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Login
{
    public partial class GameNoticeView : GComponent
    {
        public GComponent _bg_01;
        public GLabel _frame;
        public GList _tabList;
        public title_notice _content;
        public GLoader _bannerIcon;
        public const string URL = "ui://byy9k3ghv4de34";

        public static GameNoticeView CreateInstance()
        {
            return (GameNoticeView)UIPackage.CreateObject("Login", "GameNoticeView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _bg_01 = (GComponent)GetChild("bg_01");
            _frame = (GLabel)GetChild("frame");
            _tabList = (GList)GetChild("tabList");
            _content = (title_notice)GetChild("content");
            _bannerIcon = (GLoader)GetChild("bannerIcon");
        }
    }
}