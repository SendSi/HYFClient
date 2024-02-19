/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class Challenge : GComponent
    {
        public Controller _state;
        public GTextField _nameLbl;
        public GTextField _nameLbl_01;
        public GLoader3D _Boss_ldr;
        public const string URL = "ui://sinorujttg9hhz9d0q";

        public static Challenge CreateInstance()
        {
            return (Challenge)UIPackage.CreateObject("Activity", "Challenge");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _state = GetController("state");
            _nameLbl = (GTextField)GetChild("nameLbl");
            _nameLbl_01 = (GTextField)GetChild("nameLbl_01");
            _Boss_ldr = (GLoader3D)GetChild("Boss_ldr");
        }
    }
}