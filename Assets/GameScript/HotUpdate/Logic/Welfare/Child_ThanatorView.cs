﻿using FairyGUI;
using cfg;
namespace Welfare
{
    public partial class Child_ThanatorView : GComponent
    {
        public override void OnInit()
        {
            base.OnInit();

            WelfareMenuConfig cfg = (WelfareMenuConfig)(this.data);
            Debuger.LogError(cfg.Name);
        }
    }
}