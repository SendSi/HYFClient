/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class comItem_Select : GComponent
    {
        public Controller _selectCtrl;
        public comItem _comItem;
        public const string URL = "ui://2r331opvm4741qp8vi8";

        public static comItem_Select CreateInstance()
        {
            return (comItem_Select)UIPackage.CreateObject("CommonPKG", "comItem_Select");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _selectCtrl = GetController("selectCtrl");
            _comItem = (comItem)GetChild("comItem");
        }
    }
}