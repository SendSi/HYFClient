using FairyGUI;
using UnityEngine;

namespace CommonPKG
{
    public partial class Item_Currency:GComponent
    {
        private int mCurrencyId = 0;
        public void SetData(int pCfgId)
        {
            _hasNumTxt.text = BagManager.Instance.GetServerItemSum(pCfgId).ToString();
            var cfg = ConfigMgr.Instance.LoadConfigOne<ItemConfig>(pCfgId.ToString());
            _icon.icon =cfg.smallIcon;
            _addCtrl.selectedIndex = cfg.showAdd;
            mCurrencyId = pCfgId;
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}