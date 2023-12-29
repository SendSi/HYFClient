/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class circleGeneral : GComponent
    {
        public Controller _state;
        public Controller _empty;
        public GLoader _icon;
        public GGraph _mask;
        public const string URL = "ui://2r331opvhxd7hz9d7c";

        public static circleGeneral CreateInstance()
        {
            return (circleGeneral)UIPackage.CreateObject("CommonPKG", "circleGeneral");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _state = GetController("state");
            _empty = GetController("empty");
            _icon = (GLoader)GetChild("icon");
            _mask = (GGraph)GetChild("mask");
        }
    }
}