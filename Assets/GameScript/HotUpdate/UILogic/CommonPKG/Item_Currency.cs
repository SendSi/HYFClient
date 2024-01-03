using FairyGUI;
using UnityEngine;

namespace CommonPKG
{
    public partial class Item_Currency:GComponent
    {
        private int mCurrencyId = 0;
        public void SetData(int pCfgId)
        {
            _hasNumTxt.text = BagManager.GetInstance().GetServerItemSum(pCfgId).ToString();
            var cfg = ConfigMgr.GetInstance().LoadConfigOne<ItemConfig>(pCfgId.ToString());
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