/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace SettingPKG
{
    public partial class settingSelBtn : GButton
    {
        public Controller _select;
        public Transition _close;
        public Transition _open;
        public const string URL = "ui://dh3hukhzjyqri";

        public static settingSelBtn CreateInstance()
        {
            return (settingSelBtn)UIPackage.CreateObject("SettingPKG", "settingSelBtn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _select = GetController("select");
            _close = GetTransition("close");
            _open = GetTransition("open");
        }
    }
}