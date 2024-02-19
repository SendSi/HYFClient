/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Welfare
{
    public partial class FristChargeView : GComponent
    {
        public GLoader3D _spine;
        public GTextField _title;
        public GTextField _des;
        public GTextField _des1;
        public GButton _rewardBtn;
        public GTextField _time;
        public GList _list;
        public const string URL = "ui://340eighfd1gb1ygcflu";

        public static FristChargeView CreateInstance()
        {
            return (FristChargeView)UIPackage.CreateObject("Welfare", "FristChargeView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _spine = (GLoader3D)GetChild("spine");
            _title = (GTextField)GetChild("title");
            _des = (GTextField)GetChild("des");
            _des1 = (GTextField)GetChild("des1");
            _rewardBtn = (GButton)GetChild("rewardBtn");
            _time = (GTextField)GetChild("time");
            _list = (GList)GetChild("list");
        }
    }
}