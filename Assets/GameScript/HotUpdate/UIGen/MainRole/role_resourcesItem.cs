/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace MainRole
{
    public partial class role_resourcesItem : GButton
    {
        public GTextField _number;
        public const string URL = "ui://66sh7tc6j3xs9pg";

        public static role_resourcesItem CreateInstance()
        {
            return (role_resourcesItem)UIPackage.CreateObject("MainRole", "role_resourcesItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _number = (GTextField)GetChild("number");
        }
    }
}