/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace MainCenter
{
    public partial class main_taskitem_list : GComponent
    {
        public Controller _hideOpen;
        public GList _taskList;
        public const string URL = "ui://4ni413lal21a1ygcfht";

        public static main_taskitem_list CreateInstance()
        {
            return (main_taskitem_list)UIPackage.CreateObject("MainCenter", "main_taskitem_list");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _hideOpen = GetController("hideOpen");
            _taskList = (GList)GetChild("taskList");
        }
    }
}