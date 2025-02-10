using FairyGUI;
using System.Collections.Generic;
using cfg;

namespace PuzzlePKG
{
    public partial class PuzzleMainView : GComponent
    {
        private List<PuzzleConfig> mPuzzleList;

        public override void OnInit()
        {
            base.OnInit();
            this._closeButton.onClick.Set(OnClickCloseBtn);

            mPuzzleList = CfgLubanMgr.Instance.globalTab.TbPuzzleConfig.DataList;
            foreach (var item in mPuzzleList)
            {
                // GetChildByPath($"{item.Id}.mask").icon = item.UrlMask;
                // GetChild($"{item.Id}.mask").icon = item.UrlMask;
            }
        }



        private void OnClickCloseBtn()
        {
            ProxyPuzzlePKGModule.Instance.ClosePuzzleMainView();
        }

        public void SetData(string obj)
        {
        }
    }
}