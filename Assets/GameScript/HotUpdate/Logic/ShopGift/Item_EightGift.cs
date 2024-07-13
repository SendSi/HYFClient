using CommonPKG;
using FairyGUI;

#region << 脚 本 注 释 >>

//作  用:    Item_EightGift
//作  者:    曾思信
//创建时间:  #CREATETIME#

#endregion

namespace ShopGift
{
    public partial class Item_EightGift : GButton
    {
        public void SetData(EightGiftConfig cfg)
        {
            this.title = cfg.name;
            var list = FormatUtils.Instance.GetFormatItem(cfg.reward);
            _rewardCtrl.selectedIndex = (list.Count - 1);
            for (int i = 0; i < list.Count; i++)
            {
                var item = (Item_BaseProp)GetChild($"icon{i+1}");
                item.OnInit();//Item_BaseProp.cs  需pop得在这里初始化
                item.SetData(list[i],true);
            }
        }
        
        
    }
}