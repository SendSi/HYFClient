using FairyGUI;

namespace CommonPKG
{
    public partial class VideoView : GComponent
    {
        public override void OnInit()
        {
            base.OnInit();
            sortingOrder = 10;

            _closeBtn.onClick.Add(() => { ProxyCommonPKGModule.Instance.CloseVideoView(); });
        }

        public void SetData(string idStr)
        {
            VideoMgr.Instance.PlayVideoId(idStr, _videoContent);
        }

        public override void Dispose()
        {
            base.Dispose();
            VideoMgr.Instance.ClearVideo();
        }
    }
}