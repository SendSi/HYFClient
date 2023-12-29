/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class comItem0 : GComponent
    {
        public Controller _useTypeCtrl;
        public GGraph _mark;
        public GLoader _itemIcon;
        public const string URL = "ui://2r331opvnv4k1ygcgqx";

        public static comItem0 CreateInstance()
        {
            return (comItem0)UIPackage.CreateObject("CommonPKG", "comItem0");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _useTypeCtrl = GetController("useTypeCtrl");
            _mark = (GGraph)GetChild("mark");
            _itemIcon = (GLoader)GetChild("itemIcon");
        }
    }
}