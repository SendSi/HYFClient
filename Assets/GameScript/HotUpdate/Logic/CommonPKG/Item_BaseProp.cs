using FairyGUI;
using cfg;

namespace CommonPKG
{
    public partial class Item_BaseProp : GComponent
    {
        private cfg.ItemConfig mCfg;

        /// <summary> 根据导表id,设置道具图标和品质 与 自行去get服务端的数量 </summary>
        public void SetData(int pCfgId)
        {
            // mCfg = ConfigMgr.Instance.LoadConfigOne<ItemConfig>(pCfgId.ToString());
            mCfg = CfgLubanMgr.Instance.globalTab.TbItemConfig.Get(pCfgId);
            _propIcon.icon = mCfg.Icon;
            _qualityCtrl.selectedIndex = (mCfg.Quality - 1);

            _numTxt.text = BagManager.Instance.GetServerItemSum(pCfgId).ToString();
        }

        public void SetData(int pCfgId, int pSerNum)
        {
            // mCfg = ConfigMgr.Instance.LoadConfigOne<ItemConfig>(pCfgId.ToString());
            mCfg =  CfgLubanMgr.Instance.globalTab.TbItemConfig.Get(pCfgId);
            _propIcon.icon = mCfg.Icon;
            _qualityCtrl.selectedIndex = (mCfg.Quality - 1);

            _numTxt.text = pSerNum.ToString();
        }

        public void SetData(ItemProp prop, bool isNeedPop = false)
        {
            // mCfg = ConfigMgr.Instance.LoadConfigOne<ItemConfig>(prop.id.ToString());
            mCfg = CfgLubanMgr.Instance.globalTab.TbItemConfig.Get(prop.Id);
            _propIcon.icon = mCfg.Icon;
            _qualityCtrl.selectedIndex = (mCfg.Quality - 1);
            _numTxt.text = prop.Num.ToString();

            if (isNeedPop)
            {
                this.onClick.Set(() => { ProxyCommonPKGModule.Instance.ShowPopupItem1(this, prop); });
            }
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}