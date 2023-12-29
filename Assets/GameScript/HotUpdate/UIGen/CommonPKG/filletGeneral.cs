/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class filletGeneral : GComponent
    {
        public Controller _state;
        public Controller _empty;
        public GLoader _icon;
        public GGraph _mask;
        public const string URL = "ui://2r331opvjas1hz9d7z";

        public static filletGeneral CreateInstance()
        {
            return (filletGeneral)UIPackage.CreateObject("CommonPKG", "filletGeneral");
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