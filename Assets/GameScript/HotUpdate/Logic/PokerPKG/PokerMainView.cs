using FairyGUI;
using System.Collections.Generic;


namespace PokerPKG
{
    public partial class PokerMainView : GComponent
    {
        private List<PokerConfig> mSelfCardList;

        public override void OnInit()
        {
            base.OnInit();
            this._closeButton.onClick.Set(OnClickCloseBtn);

            this._selfCardList.itemRenderer = OnRenderSelfCardList;
            this._selfCardList.onClickItem.Set(OnClickItemSelfCard);
            mSelfCardList = PokerManager.Instance.GetSelfCardList();
            mSelfCardList.Sort((a, b) => b.id.CompareTo(a.id));
            this._selfCardList.numItems = mSelfCardList.Count;

            this._sendPokerBtn.onClick.Set(OnClickSendPoker);
            this._stateCtrl.selectedIndex = 1;

            this._giveUpBtn.onClick.Set(OnClickGiveUpBtn);

            this._leftCardList.numItems = 13;
            this._rightCardList.numItems = 13;
        }

        private void OnClickGiveUpBtn()
        {
            this._selfCardList.ClearSelection();
        }

        void OnClickSendPoker()
        {
            var item = this._selfCardList.GetSelection();
            for (int i = 0; i < item.Count; i++)
            {
                Debuger.LogError($"从0开始,选中索引 {item[i]}");
            }
        }

        private void OnClickItemSelfCard(EventContext context)
        {
            var gb = (GButton)(context.data);
            Debuger.Log(gb.data);
        }

        private void OnRenderSelfCardList(int index, GObject item)
        {
            var dto = mSelfCardList[index];
            item.icon = dto.urlIcon;
            item.data = dto;
        }

        private void OnClickCloseBtn()
        {
            ProxyPokerPKGModule.Instance.ClosePokerMainView();
        }

        public void SetData(string obj)
        {
        }
    }
}
