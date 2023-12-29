/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class SeasonItemView : GButton
    {
        public GLoader _bg;
        public const string URL = "ui://2r331opvw5x51ygcgq6";

        public static SeasonItemView CreateInstance()
        {
            return (SeasonItemView)UIPackage.CreateObject("CommonPKG", "SeasonItemView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _bg = (GLoader)GetChild("bg");
        }
    }
}