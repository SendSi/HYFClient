using FairyGUI;

namespace CommonPKG
{
    public partial class LoadingView : GComponent
    {
        public override void OnInit()
        {
            base.OnInit();
            sortingOrder = 10;
           
        }

        public void SetData()
        {
            _bar.max = 100;
            _bar.value = 0;
            _bar.TweenValue(100, 1);
        }

        public override void Dispose()
        {
            base.Dispose();
            VideoMgr.Instance.ClearVideo();
        }
    }
}