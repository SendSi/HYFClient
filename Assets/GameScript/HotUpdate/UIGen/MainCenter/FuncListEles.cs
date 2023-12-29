/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace MainCenter
{
    public partial class FuncListEles : GComponent
    {
        public Controller _switchCtrl;
        public GList _btnFuncList;
        public GButton _switchBtn;
        public Transition _contractDT;
        public Transition _expandDT;
        public const string URL = "ui://4ni413laxoe1mz";

        public static FuncListEles CreateInstance()
        {
            return (FuncListEles)UIPackage.CreateObject("MainCenter", "FuncListEles");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _switchCtrl = GetController("switchCtrl");
            _btnFuncList = (GList)GetChild("btnFuncList");
            _switchBtn = (GButton)GetChild("switchBtn");
            _contractDT = GetTransition("contractDT");
            _expandDT = GetTransition("expandDT");
        }
    }
}