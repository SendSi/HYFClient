/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class chief_rbtn : GButton
    {
        public Controller _label;
        public Controller _sta;
        public Controller _refres;
        public GLoader _icon_head;
        public GTextField _title_name;
        public GList _Star;
        public GTextField _GradeLbl;
        public GTextField _conditionLbl;
        public GImage _stateLbl;
        public GImage _labelbg;
        public GTextField _refresh;
        public const string URL = "ui://sinorujtw84wx";

        public static chief_rbtn CreateInstance()
        {
            return (chief_rbtn)UIPackage.CreateObject("Activity", "chief_rbtn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _label = GetController("label");
            _sta = GetController("sta");
            _refres = GetController("refres");
            _icon_head = (GLoader)GetChild("icon_head");
            _title_name = (GTextField)GetChild("title_name");
            _Star = (GList)GetChild("Star");
            _GradeLbl = (GTextField)GetChild("GradeLbl");
            _conditionLbl = (GTextField)GetChild("conditionLbl");
            _stateLbl = (GImage)GetChild("stateLbl");
            _labelbg = (GImage)GetChild("labelbg");
            _refresh = (GTextField)GetChild("refresh");
        }
    }
}