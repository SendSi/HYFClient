/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Welfare
{
    public partial class LimitShopRecordView : GLabel
    {
        public GTextField _timeTxt;
        public GTextField _sourceTxt;
        public GTextField _richerTxt;
        public GTextField _sellTxt;
        public GTextField _sellNum;
        public GLoader _iconsell;
        public GTextField _profitTxt;
        public GTextField _profitNum;
        public GLoader _iconprofit;
        public GList _buildList;
        public GButton _closeButton;
        public GGroup _window;
        public const string URL = "ui://340eighfcmbv1ygcfjt";

        public static LimitShopRecordView CreateInstance()
        {
            return (LimitShopRecordView)UIPackage.CreateObject("Welfare", "LimitShopRecordView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _timeTxt = (GTextField)GetChild("timeTxt");
            _sourceTxt = (GTextField)GetChild("sourceTxt");
            _richerTxt = (GTextField)GetChild("richerTxt");
            _sellTxt = (GTextField)GetChild("sellTxt");
            _sellNum = (GTextField)GetChild("sellNum");
            _iconsell = (GLoader)GetChild("iconsell");
            _profitTxt = (GTextField)GetChild("profitTxt");
            _profitNum = (GTextField)GetChild("profitNum");
            _iconprofit = (GLoader)GetChild("iconprofit");
            _buildList = (GList)GetChild("buildList");
            _closeButton = (GButton)GetChild("closeButton");
            _window = (GGroup)GetChild("window");
        }
    }
}