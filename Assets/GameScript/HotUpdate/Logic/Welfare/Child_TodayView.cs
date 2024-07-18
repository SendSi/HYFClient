using System.Collections.Generic;
using FairyGUI;
using cfg;

namespace Welfare
{
    public partial class Child_TodayView : GComponent
    {
        private List<TodayGiftConfig> _infoList;
        private GList _rewardList;

        public override void OnInit()
        {
            base.OnInit();

            WelfareMenuConfig cfg = (WelfareMenuConfig)(this.data);
            Debuger.LogError(cfg.Name);

            _infoList = ConfigMgr.Instance.LoadConfigList<TodayGiftConfig>();
            _infoList.Sort((a, b) => { return a.id < b.id ? -1 : 1; });

            _rewardList = _rewardCom.GetChild("rewardList").asList;
            _rewardList.itemRenderer = OnRendererReward;
            _rewardList.numItems = _infoList.Count;
        }

        private void OnRendererReward(int index, GObject item)
        {
            TodayItem script = (TodayItem)item;
            script.SetData(_infoList[index]);
        }
    }
}