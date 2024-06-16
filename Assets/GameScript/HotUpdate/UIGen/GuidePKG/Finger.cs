/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GuidePKG
{
    public partial class Finger : GComponent
    {
        public GLoader _finger;
        public Transition _move1;
        public Transition _move2;
        public Transition _move3;
        public Transition _move4;
        public const string URL = "ui://vypq82a1gyzy6";

        public static Finger CreateInstance()
        {
            return (Finger)UIPackage.CreateObject("GuidePKG", "Finger");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _finger = (GLoader)GetChild("finger");
            _move1 = GetTransition("move1");
            _move2 = GetTransition("move2");
            _move3 = GetTransition("move3");
            _move4 = GetTransition("move4");
        }
    }
}