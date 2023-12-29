/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class fighting_headPortrait : GComponent
    {
        public GLoader _icon;
        public GGraph _mask;
        public const string URL = "ui://2r331opvq8mhff";

        public static fighting_headPortrait CreateInstance()
        {
            return (fighting_headPortrait)UIPackage.CreateObject("CommonPKG", "fighting_headPortrait");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _icon = (GLoader)GetChild("icon");
            _mask = (GGraph)GetChild("mask");
        }
    }
}