/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ServiceActivity
{
    public partial class serviceactivityBtn1 : GButton
    {
        public Controller _iconCtrl;
        public Controller _red;
        public GLoader _label;
        public GButton _reddot;
        public const string URL = "ui://e290e74s11e631ygcfir";

        public static serviceactivityBtn1 CreateInstance()
        {
            return (serviceactivityBtn1)UIPackage.CreateObject("ServiceActivity", "serviceactivityBtn1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _iconCtrl = GetController("iconCtrl");
            _red = GetController("red");
            _label = (GLoader)GetChild("label");
            _reddot = (GButton)GetChild("reddot");
        }
    }
}