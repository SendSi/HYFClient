using FairyGUI;
using UnityEngine;

namespace CommonPKG
{
    public partial class RedPoint : GComponent
    {
        private RedDotDefine redKey;

        public void SetData(RedDotDefine type)
        {
            redKey = type;
            // Debug.LogError($"RedPoint.cs 加注 ：{redKey}");
            RedDotManager.Instance.RegisterRedDotChangeEvent(redKey, OnRedDotStateChangeEvent);
            RedDotManager.Instance.UpdateRedDotState(redKey);
        }

        public void OnRedDotStateChangeEvent(RedDotEnum rEnum, bool active, int count)
        {
            // Debug.LogError($"RedPoint.cs OnRedDotStateChangeEvent ：{type}  {active}  {count}");
            if (active)
            {
                if (rEnum == RedDotEnum.NodeNum)
                {
                    _title.text = count.ToString();
                    _showCtrl.selectedIndex = 2;
                }
                else if (rEnum == RedDotEnum.Normal)
                {
                    _showCtrl.selectedIndex = 1;
                }
            }
            else
            {
                _showCtrl.selectedIndex = 0;
            }
        }


        public override void Dispose()
        {
            if (redKey != null && (int)redKey > 0)
            {
                // Debug.LogError($"将 减注 ：{redKey}");
                RedDotManager.Instance.UnRegisterRedDotChangeEvent(redKey, OnRedDotStateChangeEvent);
            }

            base.Dispose();
        }
    }
}