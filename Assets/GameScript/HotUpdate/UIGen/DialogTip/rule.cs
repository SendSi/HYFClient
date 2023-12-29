/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace DialogTip
{
    public partial class rule : GComponent
    {
        public GTextField _contentTitle;
        public const string URL = "ui://utp01xiahsk61ygcfhx";

        public static rule CreateInstance()
        {
            return (rule)UIPackage.CreateObject("DialogTip", "rule");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _contentTitle = (GTextField)GetChild("contentTitle");
        }
    }
}