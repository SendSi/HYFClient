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

        public void SetData(string idStr)
        {
           
        }

        public override void Dispose()
        {
            base.Dispose();
            VideoMgr.Instance.ClearVideo();
        }
    }
}