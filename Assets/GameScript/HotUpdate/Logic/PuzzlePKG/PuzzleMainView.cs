using FairyGUI;
using System.Collections.Generic;
using cfg;
using UnityEngine;

namespace PuzzlePKG
{
    public partial class PuzzleMainView : GComponent
    {
        private List<PuzzleConfig> mPuzzleList;
        private int itemCellValue = 170; //每个格子的大小

        public override void OnInit()
        {
            EventCenter.Instance.Fire<int>((int)EventEnumAOT.EE_NumOfCircleToShow,3);

            base.OnInit();
            this._closeButton.onClick.Set(OnClickCloseBtn);

            Debug.LogError(_bg.xy);
            var maxX = _bg.x - itemCellValue;
            var maxY = _bg.y - itemCellValue;

            mPuzzleList = CfgLubanMgr.Instance.globalTab.TbPuzzleConfig.DataList;
            ShuffleList(mPuzzleList); //数据打乱一下
            foreach (var item in mPuzzleList)
            {
                var btnGo = GetChild(item.Id.ToString());
                var btnGo_icon = GetChildByPath($"{item.Id}.icon");
                btnGo_icon.size = new Vector2(1020, 680); //固定尺寸
                btnGo_icon.SetXY(item.IconPos.Xx, item.IconPos.Yy);

                btnGo_icon.data = new Vector2Int(item.CellPos.Xx, item.CellPos.Yy); //结果值在  icon里的data
                btnGo.data = new Vector2Int(-1, -1); //初始值

                //x 1130 maxX             //y95 maxY
                var xyRandom = new Vector2(Random.Range(1130, maxX), Random.Range(20, maxY));
                btnGo.xy = xyRandom;
                if (Random.Range(1, 6) == 3) btnGo.parent.SetChildIndex(btnGo, btnGo.parent.numChildren - 1); //打乱一下

                btnGo.draggable = true;
                btnGo.onDragStart.Add((EventContext context) => { btnGo.parent.SetChildIndex(btnGo, btnGo.parent.numChildren - 1); }); //最外层
                btnGo.onDragEnd.Add((EventContext context) =>
                {
                    int xCell = (int)(btnGo.x / itemCellValue);
                    int yCell = (int)(btnGo.y / itemCellValue);

                    if (btnGo.x < -120) xCell = -1;
                    if (btnGo.y < -110) yCell = -1;

                    btnGo.data = new Vector2Int(xCell, yCell); //拖动结束 设置值
                    if (xCell < 0 || xCell >= 6 || yCell >= 4 || yCell < 0)
                    {
                    }
                    else
                    {
                        //4行  6列
                        btnGo.SetXY(50 + itemCellValue * xCell, 60 + itemCellValue * yCell);
                    }

                    if (btnGo_icon.data.Equals(btnGo.data))
                    {
                        CheckGameIsFinish();
                    }
                });
            }
        }

        private void ShuffleList(List<PuzzleConfig> list)
        {
            for (int i = list.Count - 1; i > 0; i--)
            {
                int j = UnityEngine.Random.Range(0, i + 1);
                PuzzleConfig temp = list[i];
                list[i] = list[j];
                list[j] = temp;
            }
        }

        private void CheckGameIsFinish()
        {
            var index = 0;
            foreach (var item in mPuzzleList)
            {
                var btnGo = GetChild(item.Id.ToString());
                var btnGo_icon = GetChildByPath($"{item.Id}.icon");
                if (btnGo.data.Equals(btnGo_icon.data))
                {
                    index++;
                }
            }

            if (index == 3)
            {
                ProxyCommonPKGModule.Instance.AddToastStr("你已拼了三个啦,加油~~");
            }
            else if (index >= 24)
            {
                Debug.LogError("拼图 完成了");
                ProxyCommonPKGModule.Instance.AddToastStr("拼图完成了");
                ProxyDialogTipModule.Instance.OpenDialogTip1ViewWin("恭喜", "拼图完成了", "确定", null);
            }

            Debug.Log($"拼了 {index} 块了");
        }

        private void OnClickCloseBtn()
        {
            ProxyPuzzlePKGModule.Instance.ClosePuzzleMainView();
        }

        public void SetData(string obj)
        {
        }

        public override void Dispose()
        {
            base.Dispose();
            EventCenter.Instance.Fire<int>((int)EventEnumAOT.EE_NumOfCircleToShow,2);
        }
    }
}