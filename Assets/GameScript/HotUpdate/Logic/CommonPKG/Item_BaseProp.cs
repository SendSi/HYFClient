using FairyGUI;
using UnityEngine;

namespace CommonPKG
{
    public partial class Item_BaseProp : GComponent
    {
        private ItemConfig mCfg;

        public void SetData(int pCfgId)
        {
            mCfg = ConfigMgr.Instance.LoadConfigOne<ItemConfig>(pCfgId.ToString());
            _propIcon.icon = mCfg.icon;
            _qualityCtrl.selectedIndex = (mCfg.quality - 1);
            
            _numTxt.text = BagManager.Instance.GetServerItemSum(pCfgId).ToString();
        }

        public void SetData(ItemProp prop)
        {
            mCfg = ConfigMgr.Instance.LoadConfigOne<ItemConfig>(prop.id.ToString());
            _propIcon.icon = mCfg.icon;
            _qualityCtrl.selectedIndex = (mCfg.quality - 1);
            _numTxt.text = prop.num.ToString();
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}