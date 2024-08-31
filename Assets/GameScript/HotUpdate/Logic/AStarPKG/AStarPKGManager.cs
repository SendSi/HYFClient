using System.Collections.Generic;
using UnityEngine;

public class AStarPKGManager : Singleton<AStarPKGManager>
{
    private int mapW;
    private int mapH;

    public AStarNode[,] mapNodes;
    public List<AStarNode> openList = new List<AStarNode>();
    public List<AStarNode> closeList = new List<AStarNode>();

    public AStarNode[,] InitMap(int w, int h, int stopNum)
    {
        mapNodes = new AStarNode[w, h];

        mapW = w;
        mapH = h;
        for (int i = 0; i < w; i++)
        {
            for (int j = 0; j < h; j++)
            {
                mapNodes[i, j] = new AStarNode(i, j, EAStarNodeType.Walk);
            }
        }

        for (int i = 0; i < stopNum; i++)
        {
            int x = Random.Range(0, w);
            int y = Random.Range(0, h);
            mapNodes[x, y].type = EAStarNodeType.Stop; //上面已 new过了....这里只需setType
        }

        return mapNodes;
    }

    public void ClearMapNodes()
    {
        foreach (var item in mapNodes)
        {
            item.ClearNode();
        }
    }

    public AStarNode[,] GetMapNodes()
    {
        return mapNodes;
    }

    public List<AStarNode> FindPath(Vector2 startPos, Vector2 endPos)
    {
        openList.Clear();
        closeList.Clear();
        Debug.LogError($"开始{startPos}     结束{endPos}");

        var sX = Mathf.FloorToInt(startPos.x);
        var sY = Mathf.FloorToInt(startPos.y);
        var eX = Mathf.FloorToInt(endPos.x);
        var eY = Mathf.FloorToInt(endPos.y);

        if (IsMapExternal(sX, sY) || IsMapExternal(eX, eY))
        {
            Debug.Log("起点or终点 越界地图外");
            return null;
        }

        var startNode = mapNodes[sX, sY];
        var endNode = mapNodes[eX, eY];
        if (startNode.type == EAStarNodeType.Stop || endNode.type == EAStarNodeType.Stop)
        {
            Debug.LogError("起点or终点 是阻挡");
            return null;
        }

        closeList.Add(startNode);

        var success = FindEndPoint(sX, sY, eX, eY);
        if (success) //是否成功找到终点
        {
            var pathEndNode = closeList[closeList.Count - 1];
            var pathList = new List<AStarNode>();
            var curNode = pathEndNode;
            while (true)
            {
                pathList.Add(curNode);
                if (curNode.father == null)
                {
                    break;
                }

                curNode = curNode.father;
            }

            pathList.Reverse(); //反转下
            return pathList;
        }

        return null;
    }

    bool FindEndPoint(int sX, int sY, int eX, int eY)
    {
        var startNode = mapNodes[sX, sY];
        for (int iii = -1; iii < 2; iii++)
        {
            for (int jjj = -1; jjj < 2; jjj++)
            {
                if (iii == 0 && jjj == 0)
                {
                    continue; //本身自己
                }

                int cx = sX + iii;
                int cy = sY + jjj;

                if (eX == cx && eY == cy) return true; //找到结束点了    return
                if (IsMapExternal(cx, cy))
                {
                    continue; //地图外
                }

                var curNode = mapNodes[cx, cy];
                if (curNode.type == EAStarNodeType.Stop)
                {
                    continue; //阻挡
                }

                //是否已经在开启列表 or 关闭列表 中了
                if (openList.Contains(curNode) || closeList.Contains(curNode))
                {
                    continue;
                }

                curNode.father = startNode; //设置父节点 
                float d = 1.4f; //计算f=g+h   默认 你斜角边的  则为1.4
                if (iii * jjj == 0) d = 1f; //横竖的 则为1 

                float g = startNode.g + d;
                float h1 = Mathf.Abs(cx - sX);
                float h2 = Mathf.Abs(cy - sY);
                float h = h1 + h2;
                float f = g + h; //f=g+h
                curNode.SetFGH(f, g, h);

                openList.Add(curNode); //开放列表
            }
        }

        if (openList.Count <= 0)
        {
            Debug.LogError("死路");
            return false;
        }

        foreach (var item in openList)
        {
            if (item == null)
            {
                Debug.LogError("?");
            }
        }

        openList.Sort(CompareAStarNodes);
        var minNode = openList[0]; //最短一个节点
        closeList.Add(minNode); //加
        openList.RemoveAt(0); //移

        if (minNode.x == eX && minNode.y == eY)
        {
            return true;
        }

        //自己调用自己
        return FindEndPoint(minNode.x, minNode.y, eX, eY);
    }
    
    public int CompareAStarNodes(AStarNode nod1, AStarNode nod2)
    {
        if (nod1.f < nod2.f)
        {
            return -1;
        }
        else if (nod1.f > nod2.f)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }


    /// <summary> true则越界 </summary>
    bool IsMapExternal(int x, int y)
    {
        if (x < 0 || x >= mapW || y < 0 || y >= mapH)
        {
            return true;
        }

        return false;
    }
}