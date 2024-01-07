using CommonPKG;
using FairyGUI;
using UnityEngine;

namespace MainCenter
{
    public partial class Main_btn : GButton
    {
        public void SetData(FuncBtnData data)
        {
            if (data != null)
            {
                this.icon = data.iconURL;
                this.title = data.titleTxt;
                this.onClick.Set(() => { data.clikcAct?.Invoke(); });

                if (data.fId == 1003)
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

            Debug.Log("OnStoreRedDotLogicHandler:" + redNode.redDotActive);
        }
    }
}