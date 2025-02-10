using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Linq;
using FairyGUI;
using UnityEngine;

public class Test003 : MonoBehaviour
{
    void Start()
    {
        //Test();

        UniTaskAsyncEnumerable.EveryUpdate().Subscribe(x => { }, () => { });
    }

    AsyncReactiveProperty<int> count = new AsyncReactiveProperty<int>(0);
    private GTextField abc;
    void OnGUI()
    {
        if (GUILayout.Button("Test"))
        {
            Test();

            
            // count.BindTo(abc);
            count.Value = 0;
            count.Subscribe(x =>
            {
                abc.text = x.ToString();
            }, () => { });
        }
    }


    void Test()
    {
        List<Vector2Int> tPath = new List<Vector2Int>();
        tPath.Add(new Vector2Int(3, -4));
        tPath.Add(new Vector2Int(3, -3));
        tPath.Add(new Vector2Int(4, -4));
        tPath.Add(new Vector2Int(4, -3));
        tPath.Add(new Vector2Int(5, -4));
        tPath.Add(new Vector2Int(5, -3));

        int tMaxX = -999, tMaxY = -999, tMinX = 999, tMinY = 999;
        foreach (Vector2Int tPos in tPath)
        {
            if (tPos.x > tMaxX) tMaxX = tPos.x;
            if (tPos.y > tMaxY) tMaxY = tPos.y;
            if (tPos.x < tMinX) tMinX = tPos.x;
            if (tPos.y < tMinY) tMinY = tPos.y;
        }

        Debug.LogError("MaxX: " + tMaxX + " MaxY: " + tMaxY + " MinX: " + tMinX + " MinY: " + tMinY);


        tMaxX += 1;
        tMaxY += 1;
        tMinX -= 1;
        tMinY -= 1;

        Debug.Log("MaxX: " + tMaxX + " MaxY: " + tMaxY + " MinX: " + tMinX + " MinY: " + tMinY);
        for (int x = tMinX; x <= tMaxX; x++)
        {
            for (int y = tMinY; y <= tMaxY; y++)
            {
                if (tPath.Contains(new Vector2Int(x, y)) == false)
                {
                    // Debug.Log("add Path at: " + x + " " + y);
                    tPath.Add(new Vector2Int(x, y));
                }
            }
        }

        foreach (Vector2Int tPos in tPath)
        {
            if (tPos.x > tMaxX) tMaxX = tPos.x;
            if (tPos.y > tMaxY) tMaxY = tPos.y;
            if (tPos.x < tMinX) tMinX = tPos.x;
            if (tPos.y < tMinY) tMinY = tPos.y;
        }

        Debug.LogError("MaxX: " + tMaxX + " MaxY: " + tMaxY + " MinX: " + tMinX + " MinY: " + tMinY);
    }
}