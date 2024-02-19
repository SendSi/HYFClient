/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Welfare
{
    public partial class DiamondMallView : GLabel
    {
        public GTextField _explainLbl;
        public GTextField _GradeLbl;
        public GTextField _explainLbl01;
        public GList _list;
        public const string URL = "ui://340eighf9sqn1ygcfib";

        public static DiamondMallView CreateInstance()
        {
            return (DiamondMallView)UIPackage.CreateObject("Welfare", "DiamondMallView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _explainLbl = (GTextField)GetChild("explainLbl");
            _GradeLbl = (GTextField)GetChild("GradeLbl");
            _explainLbl01 = (GTextField)GetChild("explainLbl01");
            _list = (GList)GetChild("list");
        }
    }
}