/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class comItem : GButton
    {
        public Controller _useTypeCtrl;
        public Controller _qualityCtrl;
        public Controller _keepCtrl;
        public Controller _topNameCtrl;
        public GLoader _qualityIcon;
        public GLoader _itemIcon;
        public GGroup _icon_bg;
        public GLoader _fragmentIcon;
        public generalFragment _iconFragment;
        public GImage _image;
        public GGroup _2_fragment;
        public generalFragment01 _Keepsake;
        public GTextField _hasNumTxt;
        public GProgressBar _composePbr;
        public GTextField _exceedTime;
        public GGroup _4_exceedTime;
        public GTextField _ReincarnationLbl;
        public GGroup _keep;
        public GTextField _topNameTxt;
        public GGroup _topName;
        public const string URL = "ui://2r331opvj842hz9cyi";

        public static comItem CreateInstance()
        {
            return (comItem)UIPackage.CreateObject("CommonPKG", "comItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _useTypeCtrl = GetController("useTypeCtrl");
            _qualityCtrl = GetController("qualityCtrl");
            _keepCtrl = GetController("keepCtrl");
            _topNameCtrl = GetController("topNameCtrl");
            _qualityIcon = (GLoader)GetChild("qualityIcon");
            _itemIcon = (GLoader)GetChild("itemIcon");
            _icon_bg = (GGroup)GetChild("icon_bg");
            _fragmentIcon = (GLoader)GetChild("fragmentIcon");
            _iconFragment = (generalFragment)GetChild("iconFragment");
            _image = (GImage)GetChild("image");
            _2_fragment = (GGroup)GetChild("2_fragment");
            _Keepsake = (generalFragment01)GetChild("Keepsake");
            _hasNumTxt = (GTextField)GetChild("hasNumTxt");
            _composePbr = (GProgressBar)GetChild("composePbr");
            _exceedTime = (GTextField)GetChild("exceedTime");
            _4_exceedTime = (GGroup)GetChild("4_exceedTime");
            _ReincarnationLbl = (GTextField)GetChild("ReincarnationLbl");
            _keep = (GGroup)GetChild("keep");
            _topNameTxt = (GTextField)GetChild("topNameTxt");
            _topName = (GGroup)GetChild("topName");
        }
    }
}