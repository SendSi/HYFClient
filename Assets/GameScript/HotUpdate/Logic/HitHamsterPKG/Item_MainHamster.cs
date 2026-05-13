using System;
using FairyGUI;
using UnityEngine;


namespace HitHamsterPKG
{
    public partial class Item_MainHamster : GComponent
    {
        private int mIndex = 0;

        /// <summary> 0空状态  1露头中  2被打中  3偷跑中  4被炸中  5被加时 </summary>
        private int mRunState = 0;

        /// <summary> 0空状态  1露头中  2被打中  3偷跑中  4被炸中  5被加时 </summary>
        public int GetRunState()
        {
            return mRunState;
        }

        public override void OnInit()
        {
            base.OnInit();
            _hamster.SetColorState(5); //5为空   0晕  1黄 2蓝 3炸弹 4时钟   _hamster=Item_MaskHamster.cs
            EventCenter.Instance.Bind<int, int>((int)EventEnumHOT.EE_ShowHamsterItem, OnEventShowHamsterItem);
        }

        public void SetGenHamster()
        {
            _hamster.SetColorState(UnityEngine.Random.Range(1, 5));

            mRunState = 1;
            _hamster.PlayTrMove(delegate
            {
                mRunState = 3;
                FairyGUI.Timers.inst.Add(1f, 1, delegate { mRunState = 0; });
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

        /// <summary>
        /// 打击下
        /// </summary>
        public void SetClickItem()
        {
            if (mRunState == 1)
            {
                var colorHam = _hamster.GetColorState(); // 0晕  1黄  2蓝  3炸弹  4时钟 5空 </summary>
                if (colorHam == 0 || colorHam == 5)
                {
                    return;
                }

                if (colorHam == 1)
                {
                    Debug.Log("加1分");
                }
                else if (colorHam == 2)
                {
                    Debug.Log("加2分");
                }
                else if (colorHam == 3)
                {
                    Debug.Log("扣血");
                }
                else if (colorHam == 4)
                {
                    Debug.Log("加时间");
                }

                _hamster.PlayTrKit(); //播放锤子
            }
        }
    }
}