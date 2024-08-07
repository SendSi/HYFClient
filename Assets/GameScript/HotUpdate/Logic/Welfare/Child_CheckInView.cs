﻿using System.Collections.Generic;
using FairyGUI;
using cfg;

namespace Welfare
{
    public partial class Child_CheckInView : GComponent
    {
        private GList _dayList;
        private TimerCallback timerCB;
        private List<cfg.CheckInConfig> _cfgInfos;

        public override void OnInit()
        {
            base.OnInit();

            _cfgInfos = CfgLubanMgr.Instance.globalTab.TbCheckInConfig.DataList;// ConfigMgr.Instance.LoadConfigList<CheckInConfig>(); //整个表
            _cfgInfos.Sort((a, b) =>            {                return a.Id < b.Id ? -1 : 1;            });

            WelfareMenuConfig cfg = (WelfareMenuConfig)(this.data);
            Debuger.LogError(cfg.Name);

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