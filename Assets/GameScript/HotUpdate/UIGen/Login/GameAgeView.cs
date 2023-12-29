/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Login
{
    public partial class GameAgeView : GComponent
    {
        public GComponent _bg_01;
        public GLabel _frame;
        public title_notice1 _content;
        public const string URL = "ui://byy9k3gha9my1ygcg9y";

        public static GameAgeView CreateInstance()
        {
            return (GameAgeView)UIPackage.CreateObject("Login", "GameAgeView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _bg_01 = (GComponent)GetChild("bg_01");
            _frame = (GLabel)GetChild("frame");
            _content = (title_notice1)GetChild("content");
        }
    }
}