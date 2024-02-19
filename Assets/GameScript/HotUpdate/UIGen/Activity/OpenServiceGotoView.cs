/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class OpenServiceGotoView : GLabel
    {
        public GComponent _mask;
        public GButton _closeButton;
        public GTextField _nameLbl;
        public GList _list;
        public GGroup _group;
        public const string URL = "ui://sinorujtefo21ygcfiv";

        public static OpenServiceGotoView CreateInstance()
        {
            return (OpenServiceGotoView)UIPackage.CreateObject("Activity", "OpenServiceGotoView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _mask = (GComponent)GetChild("mask");
            _closeButton = (GButton)GetChild("closeButton");
            _nameLbl = (GTextField)GetChild("nameLbl");
            _list = (GList)GetChild("list");
            _group = (GGroup)GetChild("group");
        }
    }
}