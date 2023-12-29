/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class FloatItem : GComponent
    {
        public GGraph _EffectHandle;
        public GLoader _icon;
        public const string URL = "ui://2r331opvaol71qp8vep";

        public static FloatItem CreateInstance()
        {
            return (FloatItem)UIPackage.CreateObject("CommonPKG", "FloatItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _EffectHandle = (GGraph)GetChild("EffectHandle");
            _icon = (GLoader)GetChild("icon");
        }
    }
}