using System.Collections.Generic;
using FairyGUI;

namespace CommonPKG
{
    public partial class ToastTipView : GComponent
    {
        public override void OnInit()
        {
            base.OnInit();
            sortingOrder = 999;
            _lampTipTxt = _lampCom.GetChild("title").asRichTextField;//跑马灯
        }

        #region 飘字
        private Queue<ToastItem> _tipItemPool = new Queue<ToastItem>(); //池
        private Queue<ToastItem> _useItemPool = new Queue<ToastItem>(); //使用中的池

        public void SetFloatTip(string tipTxt)
        {
            if (string.IsNullOrEmpty(tipTxt)) { return; }

            GetOrCreateTipItem(tipTxt);
        }

        private void GetOrCreateTipItem(string tipTxt)
        {
            ToastItem item = null;
            int poolCount = _tipItemPool.Count;
            if (poolCount > 0)
            {
                item = _tipItemPool.Dequeue(); //取出队列
            }
            else
            {
                item = (ToastItem)UIPackage.CreateObject("CommonPKG", "ToastItem");
                this.AddChild(item);
            }

            MoveAnimation();
            _useItemPool.Enqueue(item);
            item.ResetPos();
            item.SetTipText(tipTxt);
            item.SetAnimation(_tipItemPool, _useItemPool);
        }

        private void MoveAnimation()
        {
            foreach (var item in _useItemPool)
            {
                item.MoveAnimation();
            }
        }
        #endregion
     
        #region 跑马灯
        GRichTextField _lampTipTxt;
        Queue<string> mNeedLampStr = new Queue<string>();

        public void SetHorseLamp(string content)
        {
            if (string.IsNullOrEmpty(content)) { return; }

            int poolCount = mNeedLampStr.Count;
            if (poolCount > 0 || _horseLampGroup.visible)
            {
                mNeedLampStr.Enqueue(content); //加入队列
            }
            else
            {
                GetSetShowLampItem(content); //直接用 不加入队列
            }
        }

        private void GetSetShowLampItem(string content)
        {
            _horseLampGroup.visible = true;
            _lampTipTxt.text = content;
            _lampTipTxt.x = _lampCom.width- 60;
            _lampTipTxt.TweenMoveX(-(_lampTipTxt.width + 20), 6.5f).SetEase(EaseType.Linear).OnComplete(() =>
            {
                if (mNeedLampStr.Count > 0) GetSetShowLampItem(mNeedLampStr.Dequeue()); //取出队列 并使用

                else _horseLampGroup.visible = false;
            });
        }

        #endregion
    }
}