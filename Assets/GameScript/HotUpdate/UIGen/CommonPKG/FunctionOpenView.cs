/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class FunctionOpenView : GComponent
    {
        public GGraph _mask;
        public GLoader _icon;
        public GTextField _nameLbl;
        public GTextField _describeLbl;
        public Transition _t0;
        public const string URL = "ui://2r331opvaol71qp8ver";

        public static FunctionOpenView CreateInstance()
        {
            return (FunctionOpenView)UIPackage.CreateObject("CommonPKG", "FunctionOpenView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _mask = (GGraph)GetChild("mask");
            _icon = (GLoader)GetChild("icon");
            _nameLbl = (GTextField)GetChild("nameLbl");
            _describeLbl = (GTextField)GetChild("describeLbl");
            _t0 = GetTransition("t0");
        }
    }
}