/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class skillItem : GButton
    {
        public Controller _state;
        public Controller _grade;
        public Controller _awake;
        public EffectRoot _EffectRoot_QiangHua;
        public GImage _awaken;
        public GTextField _lv;
        public GTextField _name;
        public GImage _activeIcon;
        public const string URL = "ui://2r331opvoxy0z9cqy";

        public static skillItem CreateInstance()
        {
            return (skillItem)UIPackage.CreateObject("CommonPKG", "skillItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _state = GetController("state");
            _grade = GetController("grade");
            _awake = GetController("awake");
            _EffectRoot_QiangHua = (EffectRoot)GetChild("EffectRoot_QiangHua");
            _awaken = (GImage)GetChild("awaken");
            _lv = (GTextField)GetChild("lv");
            _name = (GTextField)GetChild("name");
            _activeIcon = (GImage)GetChild("activeIcon");
        }
    }
}