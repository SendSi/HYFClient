using System.Collections.Generic;

public class MapResData
{
    //地图id
    public int MapId;
    //x轴最大图片索引
    public int MaxX;
    //y轴最大图片索引
    public int MaxY;

    //开始的坐标（左下角的坐标）
    public float StartX;
    public float StartY;
    //结束的坐标（右上角的坐标）
    public float EndX;
    public float EndY;
    //所有小图列表
    public List<MapResBlockData> ResBlockDataList;
    public float Width;
    public float Height;

    public MapResData(int mapId, int maxX, int maxY,float startX,float startY,float endX,float endY,float width,float height)
    {
        Width = width;
        Height = height;
        EndX = endX;
        EndY = endY;
        StartX = startX;
        StartY = startY;
        this.MaxX = maxX;
        this.MaxY = maxY;
        this.MapId = mapId;
        ResBlockDataList = new List<MapResBlockData>();
    }

    public void AddBlock(string blockName, int x, int y, int width, int height, float posX, float posY)
    {
        MapResBlockData imgBlockData = new MapResBlockData(blockName, x, y, width, height, posX, posY);
        ResBlockDataList.Add(imgBlockData);
    }
}

public class MapResBlockData
{
    //图片名称
    public string BlockName;
    //图片格子索引
    public int X;
    //图片格子索引
    public int Y;
    //图片宽度
    public int Width;
    //图片高度
    public int Height;
    //图片在世界坐标的位置
    public float PosX;
    public float PosY;

    public MapResBlockData(string blockName, int x, int y, int width, int height, float posX, float posY)
    {
        BlockName = blockName;
        X = x;
        Y = y;
        Width = width;
        Height = height;
        PosX = posX;
        PosY = posY;
    }
}

public class MapResLoadData
{
    public string SpriteName;
    public List<MapBlockUnit> MapBlockUnitList;

    public void Reset()
    {
        if (MapBlockUnitList!= null)
        {
            MapBlockUnitList.Clear();
        }
    }
}