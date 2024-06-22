/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GuidePKG
{
    public partial class GuideMainView : GComponent
    {
        public GLoader _descLoader;
        public FingerCom _fingerCom;
        public const string URL = "ui://vypq82a1ddte3c";

        public static GuideMainView CreateInstance()
        {
            return (GuideMainView)UIPackage.CreateObject("GuidePKG", "GuideMainView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _descLoader = (GLoader)GetChild("descLoader");
            _fingerCom = (FingerCom)GetChild("fingerCom");
        }
    }
}