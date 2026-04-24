using System;
using FairyGUI;
using UnityEngine;


namespace HitHamsterPKG
{
    public partial class Item_MainHamster : GComponent
    {
        private int mIndex = 0;
        private int mState = 0; //0空状态  1露头中  2被打中  3偷跑中  4被炸中  5被加时

        public int GetState()
        {
            return mState;
        }

        public override void OnInit()
        {
            base.OnInit();
            _hamster.SetState(5); //5为空   0晕  1黄 2蓝 3炸弹 4时钟
            EventCenter.Instance.Bind<int, int>((int)EventEnumHOT.EE_ShowHamsterItem, OnEventShowHamsterItem);
        }

        public void SetGenHamster()
        {
            _hamster.SetState(UnityEngine.Random.Range(1, 5));

            mState = 1;
            _hamster.PlayTrMove(delegate
            {
                mState = 3;
                FairyGUI.Timers.inst.Add(1f, 1, delegate { mState = 0; });
            });
        }

        public void SetIndex(int index)
        {
            mIndex = index;
        }


        private void OnEventShowHamsterItem(int pIndex, int pCfgId)
        {
        }


        public override void Dispose()
        {
            base.Dispose();
            EventCenter.Instance.UnBind<int, int>((int)EventEnumHOT.EE_ShowHamsterItem, OnEventShowHamsterItem);
        }

        public void SetClickItem()
        {
            _hamster.PlayTrKit();
            if (mState == 1)
            {
                Debug.Log("加分");
            }
        }
    }
}