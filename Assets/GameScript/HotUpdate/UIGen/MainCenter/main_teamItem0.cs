/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace MainCenter
{
    public partial class main_teamItem0 : GComponent
    {
        public Controller _showBtn;
        public Controller _countdown;
        public GTextField _time;
        public GTextField _title1;
        public GTextField _powerNum;
        public GGraph _armsbg;
        public GTextField _title2;
        public GGroup _infor;
        public const string URL = "ui://4ni413laoepthz9cpw";

        public static main_teamItem0 CreateInstance()
        {
            return (main_teamItem0)UIPackage.CreateObject("MainCenter", "main_teamItem0");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _showBtn = GetController("showBtn");
            _countdown = GetController("countdown");
            _time = (GTextField)GetChild("time");
            _title1 = (GTextField)GetChild("title1");
            _powerNum = (GTextField)GetChild("powerNum");
            _armsbg = (GGraph)GetChild("armsbg");
            _title2 = (GTextField)GetChild("title2");
            _infor = (GGroup)GetChild("infor");
        }
    }
}