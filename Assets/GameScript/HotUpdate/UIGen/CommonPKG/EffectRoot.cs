/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class EffectRoot : GComponent
    {
        public GGraph _root;
        public const string URL = "ui://2r331opvis8cg8";

        public static EffectRoot CreateInstance()
        {
            return (EffectRoot)UIPackage.CreateObject("CommonPKG", "EffectRoot");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _root = (GGraph)GetChild("root");
        }
    }
}