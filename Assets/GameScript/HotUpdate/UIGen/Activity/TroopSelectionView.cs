/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class TroopSelectionView : GLabel
    {
        public GComponent _mask;
        public GLabel _bg;
        public GTextField _tipslbl;
        public GTextField _titleTxt;
        public GButton _cancelBtn;
        public GButton _sureBtn;
        public GButton _editBtn;
        public GList _troopsList;
        public GButton _closeButton;
        public GGroup _win;
        public const string URL = "ui://sinorujtts2v1ygcfh6";

        public static TroopSelectionView CreateInstance()
        {
            return (TroopSelectionView)UIPackage.CreateObject("Activity", "TroopSelectionView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _mask = (GComponent)GetChild("mask");
            _bg = (GLabel)GetChild("bg");
            _tipslbl = (GTextField)GetChild("tipslbl");
            _titleTxt = (GTextField)GetChild("titleTxt");
            _cancelBtn = (GButton)GetChild("cancelBtn");
            _sureBtn = (GButton)GetChild("sureBtn");
            _editBtn = (GButton)GetChild("editBtn");
            _troopsList = (GList)GetChild("troopsList");
            _closeButton = (GButton)GetChild("closeButton");
            _win = (GGroup)GetChild("win");
        }
    }
}