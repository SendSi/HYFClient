using FairyGUI;

namespace HitHamsterPKG
{
    public partial class Item_MaskHamster : GComponent
    {
        public void PlayTrMove(PlayCompleteCallback onComplete)
        {
            _TrMove.Play(onComplete);
        }
        public void PlayTrKit()
        {
            _TrKit.Play();
        }

        public void SetColorState(int state)
        {
            _stateCtrl.selectedIndex = state;
        }

        /// <summary> 0晕  1黄  2蓝  3炸弹  4时钟 5空 </summary>
        public int GetColorState()
        {
            return _stateCtrl.selectedIndex;
        }
    }
}