using System;
using System.Collections.Generic;
using FairyGUI;
using UnityEngine;

namespace HitHamsterPKG
{
    public enum HGameState
    {
        Start = 1,
        Gaming = 2,
        End = 3
    }


    public partial class HitHamsterMainView : GComponent
    {
        private int mSumTime = 300; //总时间 30秒    300则是30秒
        private int mStartTime = 4; //开始前 倒计时
        private bool mIsPlaying = false;
        private int hpValue = 5;
        private List<Item_MainHamster> mItemMain = new List<Item_MainHamster>();
        private bool isPause = false; //是否暂停

        public override void OnInit()
        {
            base.OnInit();
            mItemMain.Clear();
            _bigMarkBtn.onClick.Add(OnClickBigMaskBtn);
            _continueBtn.onClick.Add(OnClickContinueBtn);
            _stopBtn.onClick.Add(OnClickStopBtn);
            _closeButton.onClick.Add(OnClickCloseBtn);
            _hamsterList.itemRenderer = OnRenderHamsterList;
            _hamsterList.onClickItem.Add(OnClickItemHamsterList);
            _hamsterList.numItems = 9;
            _stateCtrl.onChanged.Add(OnChangedStateCtrl);

            hpValue = 5;
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
            Item_MainHamster btn = context.data as Item_MainHamster;
            btn.SetClickItem();
        }

        private void OnRenderHamsterList(int index, GObject item)
        {
            var itemHamster = item as Item_MainHamster;
            itemHamster.OnInit();
            itemHamster.SetIndex(index);
            mItemMain.Add(itemHamster);
        }

        private void OnClickCloseBtn()
        {
            ProxyHitHamsterPKGModule.Instance.CloseHitHamsterView();
        }

        private void OnClickStopBtn()
        {
            isPause = true;
            _stateCtrl.selectedIndex = 1;
        }

        private void OnClickContinueBtn()
        {
            isPause = false;
            _stateCtrl.selectedIndex = 3;
        }

        private void OnClickBigMaskBtn()
        {
            if (_stateCtrl.selectedIndex == 0)
            {
                _stateCtrl.selectedIndex = 3;
                _timeCtrl.selectedIndex = 0;
                int timeIndex = 0;
                FairyGUI.Timers.inst.Add(1, mStartTime, (p) =>
                {
                    timeIndex++;
                    _timeCtrl.selectedIndex = timeIndex;
                    if (timeIndex >= mStartTime) OnStartGame();
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
            mSumTime = 300;
            _timeTxt.text = (Mathf.CeilToInt(mSumTime * 0.1f)).ToString();
            _timeBar.max = mSumTime;
            _timeBar.value = mSumTime;
            FairyGUI.Timers.inst.Add(0.1f, -1, OnPlayingTimer);
        }


        /// <summary> 头顶的 倒计时 </summary>
        private void OnPlayingTimer(object param)
        {
            if (isPause == true)
            {
                return;
            }

            mSumTime--;
            var curTxt = (Mathf.CeilToInt(mSumTime * 0.1f));
            _timeTxt.text = curTxt.ToString();
            _timeBar.value = mSumTime;
            if (mSumTime <= 0)
            {
                mIsPlaying = false;
                _stateCtrl.selectedIndex = 2;
            }

            CheckCurrent();
        }

        void CheckCurrent()
        {
            var canShow = 0;
            List<Item_MainHamster> tCanChanges = new List<Item_MainHamster>();
            foreach (var item in mItemMain)
            {
                if (item.GetRunState() == 0)
                {
                    canShow++;
                    tCanChanges.Add(item);
                }
            }

            var gen = 0;
            if (canShow >= 9) gen++;
            if (canShow >= 8) gen++;
            if (canShow >= 7) gen++;
            if (canShow >= 6) gen++;

            if (gen <= 0) return;

            var camItems = GetRandomItems(tCanChanges, 1);
            foreach (var item in camItems)
            {
                item.SetGenHamster();
            }
        }

        List<Item_MainHamster> GetRandomItems(List<Item_MainHamster> sourceList, int gen)
        {
            System.Random random = new System.Random();
            List<Item_MainHamster> randomItems = new List<Item_MainHamster>();
            gen = Math.Min(gen, sourceList.Count);
            // 抽取随机项目
            for (int i = 0; i < gen; i++)
            {
                int index = random.Next(sourceList.Count);
                randomItems.Add(sourceList[index]);
                sourceList.RemoveAt(index); // 确保不重复抽取
            }

            return randomItems;
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