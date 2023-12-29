/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class attribute_item01 : GButton
    {
        public Controller _state;
        public GTextField _num;
        public GTextField _additionNum;
        public GTextField _additionNum2;
        public const string URL = "ui://2r331opv8z991qp8vi4";

        public static attribute_item01 CreateInstance()
        {
            return (attribute_item01)UIPackage.CreateObject("CommonPKG", "attribute_item01");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _state = GetController("state");
            _num = (GTextField)GetChild("num");
            _additionNum = (GTextField)GetChild("additionNum");
            _additionNum2 = (GTextField)GetChild("additionNum2");
        }
    }
}