using System.Collections.Generic;
using FairyGUI;
using UnityEngine;

namespace AStarPKG
{
    public partial class AStarView : GComponent
    {
        Dictionary<Vector2, int> _pathDict = new Dictionary<Vector2, int>();
        private int sumItems = 0;
        private int columnCount = 0;
        private AStarNode[,] mapNodes;

        private List<int[]> clickPos = new List<int[]>();


        public override void OnInit()
        {
            base.OnInit();
            this._inputWidth.text = "15";
            this._inputHeight.text = "15";
            this._inputPass.text = "25";

            this._closeButton.onClick.Set(() => { ProxyAStarPKGModule.Instance.CloseAStarView(); });
            this._btnGenerate.onClick.Set(OnClickGenerateBtn);
            this._btnReset.onClick.Add(OnClickReClickBtn);
            this._exTipBtn.onClick.Add(OnClickExTipBtn);

            this._listContent.itemRenderer = OnRenderListItem;
            this._listContent.onClickItem.Add(OnClickItemContent);

            OnClickGenerateBtn(); //相当于点击下
        }



        private void OnClickReClickBtn()
        {
            clickPos.Clear();
            AStarPKGManager.Instance.ClearMapNodes();
            for (int i = 0; i < this._listContent.numItems; i++)
            {
                var item = (Item_Cell)this._listContent.GetChildAt(i);
                item.RePathNone();
            }
        }

        private void OnClickItemContent(EventContext context)
        {
            var clickItem = (Item_Cell)context.data;
            var pos = clickItem.GetValueXY();
            if (clickPos.Count <= 0)
            {
                clickPos.Add(pos);
                clickItem.SetColorCtrl(2); //0白.可行走区域  2蓝.起点   3紫.终点   4绿.路径   5黄.寻路点
            }
            else if (clickPos.Count == 1)
            {
                clickPos.Add(pos);
                clickItem.SetColorCtrl(3); //0白.可行走区域  2蓝.起点   3紫.终点   4绿.路径   5黄.寻路点
                var start = new Vector2(clickPos[0][0], clickPos[0][1]);
                var end = new Vector2(pos[0], pos[1]);
                var tList = AStarPKGManager.Instance.FindPath(start, end);
                foreach (var item in tList)
                {
                    if (item.x == start.x && item.y == start.y)
                    {
                    }
                    else
                    {
                        EventCenter.Instance.Fire<AStarNode>((int)EventEnumHOT.EE_AStarPoint, item);
                    }
                }
            }
        }

        private void OnClickGenerateBtn()
        {
            columnCount = int.Parse(this._inputWidth.text);
            var heightT = int.Parse(this._inputHeight.text);
            sumItems = columnCount * heightT;
            var passT = int.Parse(this._inputPass.text);
            if (columnCount <= 0 || heightT <= 0)
            {
                Debug.LogError("数据为空或小于等于0");
                return;
            }

            if (columnCount > 23 || heightT > 15)
            {
                Debug.LogError("横格子最大23,纵格子最大15");
                return;
            }

            clickPos.Clear();
            mapNodes = AStarPKGManager.Instance.InitMap(heightT,columnCount, passT);
            this._listContent.columnCount = columnCount;
            this._listContent.numItems = sumItems;

            Debug.Log("Generate Path");
        }

        private void OnRenderListItem(int index, GObject item)
        {
            var com = (Item_Cell)item;
            com.OnInit();
            com.SetData(index, columnCount, mapNodes);
        }

        public override void Dispose()
        {
            base.Dispose();
        }
        
        private void OnClickExTipBtn()
        {
            var strCon = @"基本概念：
f = g + h
f： 总评估代价
g：起点到当前点的代价
h：当前点到终点的预期（或理想）代价（如果当前评估点到终点的直线上没有障碍物，则当前的总代价f不会改变）
将总代价f作为权重，每次优先遍历最小的f节点
a星算法，会在开表中寻找总花费最小的节点为评估点，遍历当前评估点附近点，在附近点，选择总代价最小的点作为评估点的下一节点

1.初始化起点，终点；将起点放入开表，作为评估点，在开表中选择总代价最小的作为评估节点，如果评估节点为终点，则结束
2.将当前的节点移除开表，放入闭表中（将当前的节点标记为已评估节点）
3.先遍历评估节点周围8个点（上下左右，左上角，右上角，左下角，右下角）,将它们放入一个临近点集合中    
4.遍历临近点集合，如果闭表已经有该点（该点已经被评估过）或者该点是障碍物，跳过该点
5. 计算 邻近点到起点总花费newcost=当前到邻近点的距离+当前点到起点的花费
6. 1)newGCost 小于之前计算的Gost，说明该点已经被遍历过，在开表中，
说明之前的路径存在绕远路，将邻近点的上一节点改为当前点,计算邻近点的f,g,h花费
2)开表中不包含该邻近点，该节点没有被遍历，不在开表，将邻近点的上一节点改为当前点，
加入开表，计算邻近点的f,g,h花费
7.重复1
上面的过程，FindEndPoint()，有代码和注释
距离的计算
给定两个坐标，计算两个坐标的路径距离";

            ProxyCommonPKGModule.Instance.OpenInfoTipViewWin(strCon);
        }
    }
}