/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class rbtn01 : GButton
    {
        public Controller _red;
        public Controller _iconCtrl;
        public GLoader _label;
        public red_dot _reddot;
        public const string URL = "ui://2r331opvmqls1ygcfi8";

        public static rbtn01 CreateInstance()
        {
            return (rbtn01)UIPackage.CreateObject("CommonPKG", "rbtn01");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _red = GetController("red");
            _iconCtrl = GetController("iconCtrl");
            _label = (GLoader)GetChild("label");
            _reddot = (red_dot)GetChild("reddot");
        }
    }
}