/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace MainCenter
{
    public partial class main_btn_coord : GButton
    {
        public GTextField _coordLbl_x;
        public GTextField _coordLbl_y;
        public GButton _btn;
        public const string URL = "ui://4ni413lam47yhz9co4";

        public static main_btn_coord CreateInstance()
        {
            return (main_btn_coord)UIPackage.CreateObject("MainCenter", "main_btn_coord");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _coordLbl_x = (GTextField)GetChild("coordLbl_x");
            _coordLbl_y = (GTextField)GetChild("coordLbl_y");
            _btn = (GButton)GetChild("btn");
        }
    }
}