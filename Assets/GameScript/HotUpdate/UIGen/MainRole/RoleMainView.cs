/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace MainRole
{
    public partial class RoleMainView : GLabel
    {
        public GLabel _frame;
        public GButton _btnHead;
        public GTextField _txtRoleName;
        public GButton _btnRenaming;
        public GProgressBar _pbr;
        public GButton _btnPbr;
        public GButton _btnBuy;
        public GProgressBar _pbr2;
        public GButton _btnPbr2;
        public GButton _btnBuy2;
        public GTextField _txtLeague;
        public GTextField _txtPower;
        public GList _moenyList;
        public GButton _btn1;
        public GButton _btn2;
        public GButton _btn3;
        public GGroup _roleMain;
        public const string URL = "ui://66sh7tc6j3xs9p7";

        public static RoleMainView CreateInstance()
        {
            return (RoleMainView)UIPackage.CreateObject("MainRole", "RoleMainView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _frame = (GLabel)GetChild("frame");
            _btnHead = (GButton)GetChild("btnHead");
            _txtRoleName = (GTextField)GetChild("txtRoleName");
            _btnRenaming = (GButton)GetChild("btnRenaming");
            _pbr = (GProgressBar)GetChild("pbr");
            _btnPbr = (GButton)GetChild("btnPbr");
            _btnBuy = (GButton)GetChild("btnBuy");
            _pbr2 = (GProgressBar)GetChild("pbr2");
            _btnPbr2 = (GButton)GetChild("btnPbr2");
            _btnBuy2 = (GButton)GetChild("btnBuy2");
            _txtLeague = (GTextField)GetChild("txtLeague");
            _txtPower = (GTextField)GetChild("txtPower");
            _moenyList = (GList)GetChild("moenyList");
            _btn1 = (GButton)GetChild("btn1");
            _btn2 = (GButton)GetChild("btn2");
            _btn3 = (GButton)GetChild("btn3");
            _roleMain = (GGroup)GetChild("roleMain");
        }
    }
}