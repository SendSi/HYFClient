/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GuidePKG
{
    public partial class GuideFinger : GComponent
    {
        public Finger _fingerCom;
        public const string URL = "ui://vypq82a1srlq13";

        public static GuideFinger CreateInstance()
        {
            return (GuideFinger)UIPackage.CreateObject("GuidePKG", "GuideFinger");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _fingerCom = (Finger)GetChild("fingerCom");
        }
    }
}