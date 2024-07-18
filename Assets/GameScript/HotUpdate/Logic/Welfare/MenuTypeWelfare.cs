using FairyGUI;

namespace Welfare
{
    public partial class MenuTypeWelfare:GComponent
    {
        public void SetData(cfg.WelfareMenuConfig cfg)//data字段不能被赋值
        {
            this._title.text = cfg.Name;
        }
    }
}