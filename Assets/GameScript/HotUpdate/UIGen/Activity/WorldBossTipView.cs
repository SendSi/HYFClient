/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class WorldBossTipView : GLabel
    {
        public GComponent _mask;
        public GImage _bg;
        public GTextField _tipslbl;
        public GTextField _titleTxt;
        public GButton _cancelBtn;
        public GButton _sureBtn;
        public GButton _editBtn;
        public GList _troopsList;
        public GGroup _win;
        public const string URL = "ui://sinorujtf6wa1ygcfg6";

        public static WorldBossTipView CreateInstance()
        {
            return (WorldBossTipView)UIPackage.CreateObject("Activity", "WorldBossTipView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _mask = (GComponent)GetChild("mask");
            _bg = (GImage)GetChild("bg");
            _tipslbl = (GTextField)GetChild("tipslbl");
            _titleTxt = (GTextField)GetChild("titleTxt");
            _cancelBtn = (GButton)GetChild("cancelBtn");
            _sureBtn = (GButton)GetChild("sureBtn");
            _editBtn = (GButton)GetChild("editBtn");
            _troopsList = (GList)GetChild("troopsList");
            _win = (GGroup)GetChild("win");
        }
    }
}