/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace SpinePackage
{
    public partial class SpineMainView : GComponent
    {
        public GGraph _bg;
        public GTextField _txtName;
        public GButton _closeBtn;
        public GLoader3D _spineIcon;
        public GLoader3D _spineIcon2;
        public const string URL = "ui://dhoj786wu1ch8t";

        public static SpineMainView CreateInstance()
        {
            return (SpineMainView)UIPackage.CreateObject("SpinePackage", "SpineMainView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _bg = (GGraph)GetChild("bg");
            _txtName = (GTextField)GetChild("txtName");
            _closeBtn = (GButton)GetChild("closeBtn");
            _spineIcon = (GLoader3D)GetChild("spineIcon");
            _spineIcon2 = (GLoader3D)GetChild("spineIcon2");
        }
    }
}