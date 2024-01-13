/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace SettingPKG
{
    public partial class settingSel0 : GButton
    {
        public settingSelBtn _selbtn;
        public settingSelBtn _selbtn1;
        public settingSelBtn _selbtn2;
        public Transition _close;
        public Transition _open;
        public const string URL = "ui://dh3hukhzjyqrh";

        public static settingSel0 CreateInstance()
        {
            return (settingSel0)UIPackage.CreateObject("SettingPKG", "settingSel0");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _selbtn = (settingSelBtn)GetChild("selbtn");
            _selbtn1 = (settingSelBtn)GetChild("selbtn1");
            _selbtn2 = (settingSelBtn)GetChild("selbtn2");
            _close = GetTransition("close");
            _open = GetTransition("open");
        }
    }
}