/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class comItem_FirstReward : GComponent
    {
        public Controller _firstReward;
        public comItem _comItem;
        public GImage _bg;
        public GTextField _star;
        public GGroup _chief;
        public const string URL = "ui://2r331opvm4741qp8vi6";

        public static comItem_FirstReward CreateInstance()
        {
            return (comItem_FirstReward)UIPackage.CreateObject("CommonPKG", "comItem_FirstReward");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _firstReward = GetController("firstReward");
            _comItem = (comItem)GetChild("comItem");
            _bg = (GImage)GetChild("bg");
            _star = (GTextField)GetChild("star");
            _chief = (GGroup)GetChild("chief");
        }
    }
}