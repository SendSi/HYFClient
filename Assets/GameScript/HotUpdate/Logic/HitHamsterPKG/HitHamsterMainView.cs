using System;
using FairyGUI;
using UnityEngine;

namespace HitHamsterPKG
{
    public partial class HitHamsterMainView : GComponent
    {
        private int mSumTime = 50; //总时间 30秒
        private bool mIsPlaying = false;
        private int hpValue = 5;

        public override void OnInit()
        {
            base.OnInit();
            _bigMarkBtn.onClick.Add(OnClickBigMaskBtn);
            _stopBtn.onClick.Add(OnClickStopBtn);
            _closeButton.onClick.Add(OnClickCloseBtn);
            _hamsterList.itemRenderer = OnRenderHamsterList;
            _hamsterList.onClickItem.Add(OnClickItemHamsterList);
            _hamsterList.numItems = 9;
            _stateCtrl.onChanged.Add(OnChangedStateCtrl);

            hpValue = 1;
            _hpList.itemRenderer = OnRenderHpList;
            _hpList.numItems = 5;
        }

        void SetUIHpValue(int value)
        {
            hpValue = value;
            _hpList.numItems = value;
        }

        private void OnRenderHpList(int index, GObject item)
        {
            var itemHp = item as Item_Hp;
            itemHp._stateCtrl.selectedIndex = (hpValue > index ? 1 : 0);
        }

        private void OnClickItemHamsterList(EventContext context)
        {
            var data = context.data;
            Debug.LogError(data);
        }

        private void OnRenderHamsterList(int index, GObject item)
        {
            var itemHamster = item as Item_MainHamster;
            itemHamster.OnInit();
            itemHamster.SetData();
        }

        private void OnClickCloseBtn()
        {
            ProxyHitHamsterPKGModule.Instance.CloseHitHamsterView();
        }

        private void OnClickStopBtn()
        {
            _stateCtrl.selectedIndex = 1;
        }

        private void OnClickBigMaskBtn()
        {
            if (_stateCtrl.selectedIndex == 0)
            {
                _stateCtrl.selectedIndex = 3;
                _timeCtrl.selectedIndex = 0;
                int timeIndex = 0;
                FairyGUI.Timers.inst.Add(1, 4, (p) =>
                {
                    timeIndex++;
                    _timeCtrl.selectedIndex = timeIndex;
                    if (timeIndex >= 4) OnStartGame();
                });
            }
        }

        public void SetScore(int value)
        {
            _scoreTxt.SetVar("score", value.ToString()).FlushVars();
        }

        private void OnStartGame()
        {
            mIsPlaying = true;
            _timeTxt.text = (Mathf.CeilToInt(mSumTime * 0.1f)).ToString();
            FairyGUI.Timers.inst.Add(0.1f, -1, OnPlayingTimer);
        }

        private void OnPlayingTimer(object param)
        {
            mSumTime--;
            _timeTxt.text = (Mathf.CeilToInt(mSumTime * 0.1f)).ToString();
            if (mSumTime <= 0)
            {
                mIsPlaying = false;
                _stateCtrl.selectedIndex = 2;
            }
        }

        private void OnChangedStateCtrl()
        {
            var ctrlValue = _stateCtrl.selectedIndex;
            if (ctrlValue == 2)
            {
                Timers.inst.Remove(OnPlayingTimer); //取消计时
            }
        }

        public void SetData(int cfgId)
        {
        }

        public override void Dispose()
        {
            base.Dispose();
            Timers.inst.Remove(OnPlayingTimer);
        }
    }
}