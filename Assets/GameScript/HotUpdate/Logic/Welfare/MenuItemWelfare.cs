﻿using FairyGUI;

namespace Welfare
{
    public partial class MenuItemWelfare : GButton
    {
        public void SetData(cfg.WelfareMenuConfig cfg)//data字段不能被赋值
        {
            this.title = cfg.Name;
            this._tagCtrl.selectedIndex = 0;
        }
    }
}