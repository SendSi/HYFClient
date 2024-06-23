using System;
using System.Collections.Generic;
using FairyGUI;

namespace MainCenter
{
    public partial class FuncListEles : GComponent
    {
        private FuncListEles mView;
        
        private List<MainUIBtnConfig> mCfgList;
        public override void OnInit()
        {
            base.OnInit();

            _btnFuncList.itemRenderer = ListItemRenderer;
            
            mCfgList = MainCenterManager.Instance.GetMainUIBtnList(1);
            _btnFuncList.numItems = mCfgList.Count;
        }

        private void ListItemRenderer(int index, GObject obj)
        {
            MainBottomBtn item = (MainBottomBtn)obj;
            item.SetData(mCfgList[index]); //MainBottomBtn.cs
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}