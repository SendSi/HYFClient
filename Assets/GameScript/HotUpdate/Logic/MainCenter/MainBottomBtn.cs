using CommonPKG;
using FairyGUI;
using UnityEngine;

namespace MainCenter
{
    public partial class MainBottomBtn : GButton
    {
        public void SetData(MainUIBtnConfig cfg)
        {
            if (cfg != null)
            {
                this.icon = cfg.iconURL;
                this.title = cfg.titleTxt;
                this.onClick.Set(() => { MainCenterManager.Instance.OnClickFuncBtn(cfg.id); });

                if (cfg.id == 1003)
                {
                    RedPoint red = (RedPoint)this._redPoint;
                    
                    red.SetData(RedDotDefine.BagRoot);
                }
                else
                {
                    // this._redPoint.GetController("showCtrl").selectedIndex = 0; //Random.Range(0, 3);//红点随机
                }
            }
        }

        private void OnBagRootRedDotLogicHandler(RedDotTreeNode redNode)
        {
            if (BagManager.Instance.GetRootRedDot())
            {
                redNode.redDotActive = false;
            }
            else
            {
                redNode.redDotActive = true;
            }

            Debuger.Log("OnStoreRedDotLogicHandler:" + redNode.redDotActive);
        }
    }
}