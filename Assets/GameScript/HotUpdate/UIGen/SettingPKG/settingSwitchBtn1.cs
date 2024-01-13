/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace SettingPKG
{
    public partial class settingSwitchBtn1 : GButton
    {
        public GTextField _off;
        public GTextField _on;
        public Transition _close;
        public Transition _open;
        public const string URL = "ui://dh3hukhzjyqrg";

        public static settingSwitchBtn1 CreateInstance()
        {
            return (settingSwitchBtn1)UIPackage.CreateObject("SettingPKG", "settingSwitchBtn1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _off = (GTextField)GetChild("off");
            _on = (GTextField)GetChild("on");
            _close = GetTransition("close");
            _open = GetTransition("open");
        }
    }
}