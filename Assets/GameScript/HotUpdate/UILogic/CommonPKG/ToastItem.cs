using System.Collections.Generic;
using FairyGUI;

namespace CommonPKG
{
    public partial class ToastItem : GComponent
    {
        private GTweener _tween;

        public override void OnInit()
        {
            base.OnInit();
            this.touchable = false;
            this.visible = true;
        }

        public void SetTipText(string tipTxt = "内容")
        {
            _titleTxt.text = tipTxt;
        }

        public void ResetPos()
        {
            GComponent parent = this.parent;//这页面
            this.SetPosition((parent.width * 0.5f - this.width * 0.5f), 150, 0);
            this.visible = true;
        }

        public void MoveAnimation()
        {
            _tween = this.TweenMoveY(this.y - 58, 0.2f);
        }

        public void SetAnimation(Queue<ToastItem> tipPool,Queue<ToastItem> usePool)
        {
            _moveAlpha.PlayReverse();
            _moveAlpha.Play(() =>
            {
                ResetPos();
                if (_tween != null)
                    _tween.SetPaused(true);

                this.visible = false;//播放完 就不显示了    并不移出Hierarchy
                usePool.Dequeue();
                tipPool.Enqueue(this);
            });
        }
    }
}
