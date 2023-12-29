/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace MainCenter
{
    public partial class main_teamStae : GComponent
    {
        public Controller _state;
        public GLoader _bg;
        public Transition _state0;
        public const string URL = "ui://4ni413laoepthz9cp8";

        public static main_teamStae CreateInstance()
        {
            return (main_teamStae)UIPackage.CreateObject("MainCenter", "main_teamStae");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _state = GetController("state");
            _bg = (GLoader)GetChild("bg");
            _state0 = GetTransition("state0");
        }
    }
}