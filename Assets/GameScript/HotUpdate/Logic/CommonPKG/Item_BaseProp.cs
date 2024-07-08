using FairyGUI;
using UnityEngine;

namespace CommonPKG
{
    public partial class Item_BaseProp : GComponent
    {
        private ItemConfig mCfg;

        /// <summary> 根据导表id,设置道具图标和品质 与 自行去get服务端的数量 </summary>
        public void SetData(int pCfgId)
        {
            mCfg = ConfigMgr.Instance.LoadConfigOne<ItemConfig>(pCfgId.ToString());
            _propIcon.icon = mCfg.icon;
            _qualityCtrl.selectedIndex = (mCfg.quality - 1);
            
            _numTxt.text = BagManager.Instance.GetServerItemSum(pCfgId).ToString();
        }
        
        public void SetData(int pCfgId,int pSerNum)
        {
            mCfg = ConfigMgr.Instance.LoadConfigOne<ItemConfig>(pCfgId.ToString());
            _propIcon.icon = mCfg.icon;
            _qualityCtrl.selectedIndex = (mCfg.quality - 1);

            _numTxt.text = pSerNum.ToString();
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