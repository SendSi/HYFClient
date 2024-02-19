/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Welfare
{
    public partial class LimitShopPreviewView : GLabel
    {
        public Controller _tabCtrl;
        public GTree _buildList;
        public GButton _heroBtn;
        public GButton _stageBtn;
        public GButton _closeButton;
        public GGroup _window;
        public const string URL = "ui://340eighfcmbv1ygcfjk";

        public static LimitShopPreviewView CreateInstance()
        {
            return (LimitShopPreviewView)UIPackage.CreateObject("Welfare", "LimitShopPreviewView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _tabCtrl = GetController("tabCtrl");
            _buildList = (GTree)GetChild("buildList");
            _heroBtn = (GButton)GetChild("heroBtn");
            _stageBtn = (GButton)GetChild("stageBtn");
            _closeButton = (GButton)GetChild("closeButton");
            _window = (GGroup)GetChild("window");
        }
    }
}