using System.Collections.Generic;
using FairyGUI;
using UnityEngine;

namespace CommonPKG
{
    public partial class CurrencyListCom : GComponent
    {

        private List<int> mCurrencyIds;
        private int mCurrencyId = 0;

        public void SetData(List<int> pCfgIds)
        {
            _currencyList.itemRenderer = (index, obj) =>
            {
                Item_Currency item = (Item_Currency)obj;
                item.SetData(mCurrencyIds[index]);//Item_Currency.cs
            };
            
            
            mCurrencyIds = pCfgIds;

            _currencyList.numItems = mCurrencyIds.Count;
            // Debug.LogError("CurrencyListCom.SetData() "+pCfgIds.Count);
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}