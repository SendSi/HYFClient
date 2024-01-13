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
        }

        private Queue<ToastItem> _tipItemPool = new Queue<ToastItem>();//池
        private Queue<ToastItem> _useItemPool = new Queue<ToastItem>();//使用中的池

        public void SetData(string tipTxt)
        {
            if (string.IsNullOrEmpty(tipTxt))
            {
                return;
            }

            GetOrCreateTipItem(tipTxt);
        }

        private void GetOrCreateTipItem(string tipTxt)
        {
            ToastItem item = null;
            int poolCount = _tipItemPool.Count;
            if (poolCount > 0)
            {
                item = _tipItemPool.Dequeue();//取出队列
            }
            else
            {
                 item= (ToastItem)UIPackage.CreateObject("CommonPKG", "ToastItem");
                 this.AddChild(item);
            }

            MoveAnimation();
            _useItemPool.Enqueue(item);
            item.ResetPos();
            item.SetTipText(tipTxt);
            item.SetAnimation(_tipItemPool,_useItemPool);
        }

        private void MoveAnimation()
        {
            foreach (var item in _useItemPool)
            {
                item.MoveAnimation();
            }
        }
    }
}
