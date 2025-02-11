using System.Collections.Generic;
using FairyGUI;
using cfg;
using UnityEngine;

namespace MainCenter
{
    public partial class MainLeftEles : GComponent
    {
        private List<MainUIBtnConfig> mCfgList;



        public override void OnInit()
        {
            base.OnInit();
            
            _otherBtn.onClick.Add(OnClickOtherBtn);
        }

        private void OnClickOtherBtn()
        {
            ProxyPuzzlePKGModule.Instance.OpenPuzzleMainView();
        }


        public override void Dispose()
        {
            base.Dispose();
      
        }
    }
}