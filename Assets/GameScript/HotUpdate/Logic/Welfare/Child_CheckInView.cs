using System.Collections.Generic;
using FairyGUI;
using UnityEngine;

namespace Welfare
{
    public partial class Child_CheckInView : GComponent
    {
        private GList _dayList;
        private TimerCallback timerCB;
        private Dictionary<string, CheckInConfig> _cfgInfos;

        public override void OnInit()
        {
            base.OnInit();

            _cfgInfos = ConfigMgr.Instance.LoadConfigDics<CheckInConfig>(); //整个表

            MenuData cfg = (MenuData)(this.data);
            Debug.LogError(cfg._name);

            _dayList = this._dayCom.GetChild("dayList").asList;
            _dayList.itemRenderer = OnRendererDayList;
            _dayList.numItems = 30;

            timerCB = CountDownTime.SetStart(864999, this._timerTxt, "剩余时间:{0}", true, null);
        }

        private void OnRendererDayList(int index, GObject item)
        {
            var obj = (CheckInItem)item;
            obj.SetData(_cfgInfos[(index + 1001).ToString()]); //CheckInItem.cs
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