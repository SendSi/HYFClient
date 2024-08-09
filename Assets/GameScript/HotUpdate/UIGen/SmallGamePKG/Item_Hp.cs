/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace SmallGamePKG
{
    public partial class Item_Hp : GComponent
    {
        public Controller _stateCtrl;
        public const string URL = "ui://q0kdbd65dbigeme";

        public static Item_Hp CreateInstance()
        {
            return (Item_Hp)UIPackage.CreateObject("SmallGamePKG", "Item_Hp");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _stateCtrl = GetController("stateCtrl");
        }
    }
}