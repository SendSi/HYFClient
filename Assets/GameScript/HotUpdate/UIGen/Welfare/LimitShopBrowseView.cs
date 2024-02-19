/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Welfare
{
    public partial class LimitShopBrowseView : GLabel
    {
        public GTextField _menber;
        public GTextField _sta;
        public GTextField _operation;
        public GList _playerList;
        public GButton _closeButton;
        public GGroup _window;
        public const string URL = "ui://340eighfcmbv1ygcfjp";

        public static LimitShopBrowseView CreateInstance()
        {
            return (LimitShopBrowseView)UIPackage.CreateObject("Welfare", "LimitShopBrowseView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _menber = (GTextField)GetChild("menber");
            _sta = (GTextField)GetChild("sta");
            _operation = (GTextField)GetChild("operation");
            _playerList = (GList)GetChild("playerList");
            _closeButton = (GButton)GetChild("closeButton");
            _window = (GGroup)GetChild("window");
        }
    }
}