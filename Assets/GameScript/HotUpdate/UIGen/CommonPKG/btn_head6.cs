/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class btn_head6 : GButton
    {
        public Controller _frame;
        public Controller _onLineCtrl;
        public GImage _selected;
        public GLoader _frame_2;
        public GImage _onLine;
        public const string URL = "ui://2r331opvho0c1ygcgnt";

        public static btn_head6 CreateInstance()
        {
            return (btn_head6)UIPackage.CreateObject("CommonPKG", "btn_head6");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _frame = GetController("frame");
            _onLineCtrl = GetController("onLineCtrl");
            _selected = (GImage)GetChild("selected");
            _frame_2 = (GLoader)GetChild("frame");
            _onLine = (GImage)GetChild("onLine");
        }
    }
}