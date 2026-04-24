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

        public void SetState(int state)
        {
            _stateCtrl.selectedIndex = state;
        }
    }
}