/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace DialogTip
{
    public partial class upgradeBg : GComponent
    {
        public Transition _t0;
        public const string URL = "ui://utp01xiax5vt1ygcfmw";

        public static upgradeBg CreateInstance()
        {
            return (upgradeBg)UIPackage.CreateObject("DialogTip", "upgradeBg");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _t0 = GetTransition("t0");
        }
    }
}