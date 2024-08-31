using FairyGUI;
using UnityEngine;

namespace AStarPKG
{
    public partial class Item_Cell : GComponent
    {
        public int[] valueXY;

        public override void OnInit()
        {
            base.OnInit();
            EventCenter.Instance.Bind<AStarNode>((int)EventEnum.EE_AStarPoint,OnEventStartPoint);
        }

        private void OnEventStartPoint(AStarNode node)
        {
            if (valueXY[0]==node.x&& valueXY[1]==node.y)
            {
                SetColorCtrl(4);
            }
        }

        public void SetData(int index, int col, AStarNode[,] node)
        {
            int x = Mathf.FloorToInt(index / col);
            int y = Mathf.FloorToInt(index % col);
            this._title.text = $"{index}\r{x},{y}";

            if (node[x, y].type == EAStarNodeType.Stop)
            {
                this._colorCtrl.selectedIndex = 1;
            }
            else
            {
                this._colorCtrl.selectedIndex = 0;
            }

            valueXY = new int[] { x, y };
        }

        public int[] GetValueXY()
        {
            return valueXY;
        }

        //0白.可行走区域  2蓝.起点   3紫.终点   4绿.路径   5黄.寻路点
        public void SetColorCtrl(int ctrl)
        {
            this._colorCtrl.selectedIndex = ctrl;
        }

        public override void Dispose()
        {
            base.Dispose();
            EventCenter.Instance.UnBind<AStarNode>((int)EventEnum.EE_AStarPoint,OnEventStartPoint);
        }

        public void RePathNone()
        {
            var sIndex = this._colorCtrl.selectedIndex;
            if (sIndex>=2)
            {
                SetColorCtrl(0);
            }
        }
    }
}