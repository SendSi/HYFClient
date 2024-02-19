/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Welfare
{
    public partial class welfare_Btn : GButton
    {
        public GLoader _costIcon;
        public GTextField _costNum;
        public Transition _t0;
        public const string URL = "ui://340eighfvsu61ygcfqt";

        public static welfare_Btn CreateInstance()
        {
            return (welfare_Btn)UIPackage.CreateObject("Welfare", "welfare_Btn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _costIcon = (GLoader)GetChild("costIcon");
            _costNum = (GTextField)GetChild("costNum");
            _t0 = GetTransition("t0");
        }
    }
}