/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace SpinePKG
{
    public partial class SpineMainView : GComponent
    {
        public GGraph _bg;
        public GLoader3D _spineIcon;
        public GTextField _txtName;
        public GButton _closeBtn;
        public const string URL = "ui://dhoj786wu1ch8t";

        public static SpineMainView CreateInstance()
        {
            return (SpineMainView)UIPackage.CreateObject("SpinePKG", "SpineMainView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _bg = (GGraph)GetChild("bg");
            _spineIcon = (GLoader3D)GetChild("spineIcon");
            _txtName = (GTextField)GetChild("txtName");
            _closeBtn = (GButton)GetChild("closeBtn");
        }
    }
}