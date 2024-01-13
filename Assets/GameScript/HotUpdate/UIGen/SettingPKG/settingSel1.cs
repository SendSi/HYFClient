/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace SettingPKG
{
    public partial class settingSel1 : GButton
    {
        public settingSelBtn _selbtn;
        public settingSelBtn _selbtn1;
        public Transition _close;
        public Transition _open;
        public const string URL = "ui://dh3hukhzjyqrj";

        public static settingSel1 CreateInstance()
        {
            return (settingSel1)UIPackage.CreateObject("SettingPKG", "settingSel1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _selbtn = (settingSelBtn)GetChild("selbtn");
            _selbtn1 = (settingSelBtn)GetChild("selbtn1");
            _close = GetTransition("close");
            _open = GetTransition("open");
        }
    }
}