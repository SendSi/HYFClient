using System.Collections.Generic;
using FairyGUI;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

namespace AStarPKG
{
    public partial class AStarView : GComponent
    {
        Dictionary<Vector2,int> _pathDict = new Dictionary<Vector2, int>();
        public override void OnInit()
        {
            base.OnInit();
            this._inputWidth.text = "5";
            this._inputHeight.text = "5";
            this._inputPass.text = "0";

            this._closeButton.onClick.Set(() => { ProxyAStarPKGModule.Instance.CloseAStarView(); });
            this._btnGenerate.onClick.Set(OnClickGenerateBtn);
            
            this._listContent.itemRenderer = OnRenderListItem;
        }

        private void OnClickGenerateBtn()
        {
            var width = int.Parse(this._inputWidth.text);
            var height = int.Parse(this._inputHeight.text);
            var pass = int.Parse(this._inputPass.text);
            if (width <= 0 || height <= 0 )
            {
                Debug.LogError("数据为空或小于等于0");
                return;
            }
            
            Debug.Log("Generate Path");
        }

        private void OnRenderListItem(int index, GObject item)
        {
            item.asCom.GetController("colorColor").selectedIndex = 0;
        }
        
        

        public override void Dispose()
        {
        }
    }
}