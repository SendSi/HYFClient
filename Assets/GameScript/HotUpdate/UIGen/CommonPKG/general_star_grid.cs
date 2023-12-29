/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class general_star_grid : GComponent
    {
        public Controller _button;
        public Controller _state;
        public GLoader _icon;
        public EffectRoot _EffectRoot_ShengXing;
        public Transition _t0;
        public const string URL = "ui://2r331opvn16mg3";

        public static general_star_grid CreateInstance()
        {
            return (general_star_grid)UIPackage.CreateObject("CommonPKG", "general_star_grid");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _button = GetController("button");
            _state = GetController("state");
            _icon = (GLoader)GetChild("icon");
            _EffectRoot_ShengXing = (EffectRoot)GetChild("EffectRoot_ShengXing");
            _t0 = GetTransition("t0");
        }
    }
}