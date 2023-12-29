/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class GlobalModalWaiting : GComponent
    {
        public Transition _t0;
        public const string URL = "ui://2r331opve6v7ji";

        public static GlobalModalWaiting CreateInstance()
        {
            return (GlobalModalWaiting)UIPackage.CreateObject("CommonPKG", "GlobalModalWaiting");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _t0 = GetTransition("t0");
        }
    }
}