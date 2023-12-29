/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace MainCenter
{
    public partial class generalIcon1 : GComponent
    {
        public Controller _quality;
        public Controller _reincanation;
        public Controller _button;
        public GLoader _bg0;
        public GLoader _bg;
        public GLoader _icon;
        public GLoader _qualityIcon;
        public main_teamStae _state;
        public const string URL = "ui://4ni413laqy501qp8vdt";

        public static generalIcon1 CreateInstance()
        {
            return (generalIcon1)UIPackage.CreateObject("MainCenter", "generalIcon1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _quality = GetController("quality");
            _reincanation = GetController("reincanation");
            _button = GetController("button");
            _bg0 = (GLoader)GetChild("bg0");
            _bg = (GLoader)GetChild("bg");
            _icon = (GLoader)GetChild("icon");
            _qualityIcon = (GLoader)GetChild("qualityIcon");
            _state = (main_teamStae)GetChild("state");
        }
    }
}