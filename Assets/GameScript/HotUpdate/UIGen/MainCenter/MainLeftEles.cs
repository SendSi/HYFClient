/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace MainCenter
{
    public partial class MainLeftEles : GComponent
    {
        public Controller _hideOpen;
        public Controller _state;
        public main_taskitem_list _taskList;
        public GTextField _title;
        public GButton _foldBtn;
        public taskBtn _taskBtn;
        public GButton _otherBtn;
        public const string URL = "ui://4ni413laxoe1n0";

        public static MainLeftEles CreateInstance()
        {
            return (MainLeftEles)UIPackage.CreateObject("MainCenter", "MainLeftEles");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _hideOpen = GetController("hideOpen");
            _state = GetController("state");
            _taskList = (main_taskitem_list)GetChild("taskList");
            _title = (GTextField)GetChild("title");
            _foldBtn = (GButton)GetChild("foldBtn");
            _taskBtn = (taskBtn)GetChild("taskBtn");
            _otherBtn = (GButton)GetChild("otherBtn");
        }
    }
}