/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class equip_suitAtt1 : GComponent
    {
        public GList _basAttList;
        public GList _addAttList;
        public GTextField _title;
        public const string URL = "ui://2r331opvs1351iy5b96";

        public static equip_suitAtt1 CreateInstance()
        {
            return (equip_suitAtt1)UIPackage.CreateObject("CommonPKG", "equip_suitAtt1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _basAttList = (GList)GetChild("basAttList");
            _addAttList = (GList)GetChild("addAttList");
            _title = (GTextField)GetChild("title");
        }
    }
}