using System.Collections.Generic;
using FairyGUI;
using UnityEngine;

namespace Welfare
{
    public partial class Child_CheckInView : GComponent
    {
        private GList _dayList;
        private TimerCallback timerCB;
        private List<CheckInConfig> _cfgInfos;

        public override void OnInit()
        {
            base.OnInit();

            _cfgInfos = ConfigMgr.Instance.LoadConfigList<CheckInConfig>(); //整个表
            _cfgInfos.Sort((a, b) =>            {                return a.id < b.id ? -1 : 1;            });

            WelfareMenuConfig cfg = (WelfareMenuConfig)(this.data);
            Debug.LogError(cfg.name);

            _dayList = this._dayCom.GetChild("dayList").asList;
            _dayList.itemRenderer = OnRendererDayList;
            _dayList.numItems = 30;

            timerCB = CountDownTime.SetStart(864999, this._timerTxt, "剩余时间:{0}", true, null);
        }

        private void OnRendererDayList(int index, GObject item)
        {
            var obj = (CheckInItem)item;
            obj.SetData(_cfgInfos[index]); //CheckInItem.cs
        }

        public override void Dispose()
        {
            base.Dispose();
            if (timerCB != null)
            {
                CountDownTime.Remove(timerCB);
                timerCB = null;
            }
        }
    }
}