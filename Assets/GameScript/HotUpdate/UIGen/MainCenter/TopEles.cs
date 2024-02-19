/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace MainCenter
{
    public partial class TopEles : GComponent
    {
        public GButton _mainPlayerBtn;
        public GProgressBar _actPbr;
        public GTextField _powerNum;
        public GTextField _nameLbl;
        public GTextField _lvLbl;
        public GList _funcList;
        public GComponent _currencyListCom;
        public GButton _settingBtn;
        public const string URL = "ui://4ni413laxoe1n2";

        public static TopEles CreateInstance()
        {
            return (TopEles)UIPackage.CreateObject("MainCenter", "TopEles");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _mainPlayerBtn = (GButton)GetChild("mainPlayerBtn");
            _actPbr = (GProgressBar)GetChild("actPbr");
            _powerNum = (GTextField)GetChild("powerNum");
            _nameLbl = (GTextField)GetChild("nameLbl");
            _lvLbl = (GTextField)GetChild("lvLbl");
            _funcList = (GList)GetChild("funcList");
            _currencyListCom = (GComponent)GetChild("currencyListCom");
            _settingBtn = (GButton)GetChild("settingBtn");
        }
    }
}