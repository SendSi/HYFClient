/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class EffectHandle : GComponent
    {
        public GGraph _handle;
        public const string URL = "ui://2r331opvayljdv";

        public static EffectHandle CreateInstance()
        {
            return (EffectHandle)UIPackage.CreateObject("CommonPKG", "EffectHandle");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _handle = (GGraph)GetChild("handle");
        }
    }
}