using FairyGUI;
using UnityEngine;

namespace Welfare
{
    public partial class Child_CheckInView : GComponent
    {
        private GList _dayList;
        private TimerCallback timerCB;

        public override void OnInit()
        {
            base.OnInit();

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
            obj.SetData(index + 1);
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