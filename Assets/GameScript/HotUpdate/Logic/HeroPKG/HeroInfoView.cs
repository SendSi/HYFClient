#region << 脚 本 注 释 >>
//作  用:    ProxySpinePKGModule
//作  者:    曾思信
//创建时间:  #CREATETIME#
#endregion

using FairyGUI;
using UnityEngine;

namespace HeroPKG
{
    public partial class HeroInfoView : GComponent
    {
        private int mCfgId;

        public override void OnInit()
        {
            base.OnInit();
            this._closeBtn.onClick.Set(() => { ProxyHeroPKGModule.Instance.CloseHeroInfoView(); });
            this._leftBtn.onClick.Set(() => OnClickLeftRightBtn(-1));
            this._rightBtn.onClick.Set(() => OnClickLeftRightBtn(1));
        }

        private void OnClickLeftRightBtn(int value)
        {
            mCfgId = mCfgId + value;
            if (mCfgId > 1004) mCfgId = 1001;
            else if (mCfgId < 1001) mCfgId = 1004;
            
            SetData(mCfgId);
        }

        public void SetData(int cfgId)
        {
            mCfgId = cfgId;
            var cfg = ConfigMgr.Instance.LoadConfigOne<HeroInfoConfig>(cfgId.ToString());
            this._spineIcon.SetSpine_YooAsset(cfg.pathURL);
        }

        public override void Dispose()
        {
            this._spineIcon.Dispose_YooAsset();
            base.Dispose();
        }
    }
}