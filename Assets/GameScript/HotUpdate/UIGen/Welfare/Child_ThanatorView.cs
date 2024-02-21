/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Welfare
{
    public partial class Child_ThanatorView : GComponent
    {
        public GLoader3D _model;
        public GTextField _name;
        public GTextField _describe;
        public GTextField _describe2;
        public GTextField _frequency;
        public GImage _fre;
        public GList _award_list;
        public GButton _goBtn;
        public GTextField _num;
        public Transition _t0;
        public const string URL = "ui://340eighfqysg1ygcfne";

        public static Child_ThanatorView CreateInstance()
        {
            return (Child_ThanatorView)UIPackage.CreateObject("Welfare", "Child_ThanatorView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _model = (GLoader3D)GetChild("model");
            _name = (GTextField)GetChild("name");
            _describe = (GTextField)GetChild("describe");
            _describe2 = (GTextField)GetChild("describe2");
            _frequency = (GTextField)GetChild("frequency");
            _fre = (GImage)GetChild("fre");
            _award_list = (GList)GetChild("award_list");
            _goBtn = (GButton)GetChild("goBtn");
            _num = (GTextField)GetChild("num");
            _t0 = GetTransition("t0");
        }
    }
}