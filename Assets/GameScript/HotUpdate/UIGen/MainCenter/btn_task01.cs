/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace MainCenter
{
    public partial class btn_task01 : GButton
    {
        public Controller _colour_title;
        public titleContent _content;
        public GComponent _EffectRoot_05_bth_task01;
        public Transition _t0;
        public const string URL = "ui://4ni413lao4i9z9cjs";

        public static btn_task01 CreateInstance()
        {
            return (btn_task01)UIPackage.CreateObject("MainCenter", "btn_task01");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _colour_title = GetController("colour_title");
            _content = (titleContent)GetChild("content");
            _EffectRoot_05_bth_task01 = (GComponent)GetChild("EffectRoot_05_bth_task01");
            _t0 = GetTransition("t0");
        }
    }
}