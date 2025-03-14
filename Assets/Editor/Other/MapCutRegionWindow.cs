using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities;
using Sirenix.Utilities.Editor;
using UnityEditor;
using UnityEngine;

public class TextureSetting : AssetPostprocessor
{
    private void OnPreprocessTexture()
    {
        if (assetPath.Contains("Assets/GameRes/Map/MapSprite/"))
        {
            TextureImporter textureImporter = (TextureImporter)assetImporter;
            textureImporter.textureType = TextureImporterType.Sprite;
        }
    }
}

[InfoBox("一般美术同学出了一张大图(10000*10000),不可能说一口气把其加载出来,手动把其切小一点,通过UniTask之类的把其加载出来 \r\n大图有要求:textureType是Default  需开启1可读写 2mipmaps\r\n通过CfgJsonMgr.Instance.LoadConfig***去加载json")]
public class MapCutRegionWindow : OdinEditorWindow
{
    [MenuItem("Tools/地图/场景大图切块")]
    static void CutImage()
    {
        var window = GetWindow<MapCutRegionWindow>();
        window.position = GUIHelper.GetEditorWindowRect().AlignCenter(700, 700);
    }

    [OnValueChanged(nameof(OnTextureValChange))] [Header("目标图片资源")] [AssetsOnly]
    public Texture2D texture;

    [ReadOnly] [Header("图片资源的尺寸")] public Vector2 textureSize;
    [Header("图片所属地图id")] public int mapId=1001;

    [OnValueChanged(nameof(OnTileSizeValChange))] [DisableIf(nameof(IsLoop))] [Header("要切成多大尺寸的小图")]
    public Vector2Int tileSize = new Vector2Int(512, 512);

    [OnValueChanged(nameof(OnIsLoopValChange))] [Header("是否是循环地图")]
    public bool IsLoop;

    [OnValueChanged(nameof(OnMapSizeValChange))] [EnableIf(nameof(IsLoop))] [Header("地图宽高")]
    public Vector2 mapSize;

    [OnValueChanged(nameof(OnCellSizeValChange))] [ShowIf(nameof(IsLoop))] [Header("要切成的尺寸比例")]
    public Vector2Int cellSize=new Vector2Int(10,10);

    [ReadOnly] [Header("左下角开始位置（范围）")] public Vector2 startPos;
    [ReadOnly] [Header("右上角结束位置（范围）")] public Vector2 endPos;
    [ReadOnly] [Header("最大格子索引")] public Vector2Int cellMaxIndex;

    void OnIsLoopValChange()
    {
        OnTextureValChange();
    }

    void OnTextureValChange()
    {
        mapSize = new Vector2(texture.width, texture.height);
        textureSize = new Vector2(texture.width, texture.height);
        OnMapSizeValChange();
    }

    void OnMapSizeValChange()
    {
        startPos = new Vector2(-(mapSize.x / 2f) / 100, -(mapSize.y / 2f) / 100);
        endPos = new Vector2(mapSize.x / 100f + startPos.x, mapSize.y / 100f + startPos.y);
        OnTileSizeValChange();
    }

    void OnTileSizeValChange()
    {
        cellMaxIndex = new Vector2Int(Mathf.CeilToInt(mapSize.x * 1f / tileSize.x), Mathf.CeilToInt(mapSize.y * 1f / tileSize.y));
    }

    void OnCellSizeValChange()
    {
        tileSize = new Vector2Int(texture.width / cellSize.x, texture.height / cellSize.y);
        OnTileSizeValChange();
    }

    [Header("保存的路径")] [ReadOnly] public string SavePath = "Assets/GameRes/Map/MapSprite/";

    [Button("切割保存", 30)]
    void SaveBtnClick()
    {
        CutTexture();
        AssetDatabase.Refresh();
        Debug.Log("保存成功");
    }

    [ShowIf(nameof(IsLoop))]
    [Button("刷新参数_可看到TileSize的值", 30)]
    void RefreshBtnClick()
    {
        OnMapSizeValChange();
        OnCellSizeValChange();
    }

    void CutTexture()
    {
        MapResData mapResData = new MapResData(mapId, cellMaxIndex.x, cellMaxIndex.y, startPos.x, startPos.y, endPos.x, endPos.y, tileSize.x, tileSize.y);
        int _x = -1;
        int _y = -1;
        for (int y = 0; y < texture.height; y += tileSize.y)
        {
            _y++;
            _x = -1;
            for (int x = 0; x < texture.width; x += tileSize.x)
            {
                _x++;
                // 计算当前要创建的小纹理中，实际需要使用到的数据尺寸，
                // 确保不越界。
                int currentWidth = Mathf.Min(tileSize.x, texture.width - x);
                int currentHeight = Mathf.Min(tileSize.y, texture.height - y);

                if (currentWidth > 0 && currentHeight > 0)
                {
                    Texture2D newTex = new Texture2D(currentWidth, currentHeight, texture.format, true);
                    newTex.mipMapBias = texture.mipMapBias;
                    newTex.anisoLevel = texture.anisoLevel;
                    newTex.filterMode = texture.filterMode;
                    newTex.alphaIsTransparency = texture.alphaIsTransparency;
                    newTex.wrapMode = texture.wrapMode;
                    newTex.wrapModeU = texture.wrapModeU;
                    newTex.wrapModeV = texture.wrapModeV;
                    newTex.wrapModeW = texture.wrapModeW;

                    Color[] pixels = texture.GetPixels(x, y, currentWidth, currentHeight);

                    newTex.SetPixels(pixels);
                    newTex.Apply();
                    byte[] bytes = newTex.EncodeToPNG();
                    string fileName = texture.name + string.Format("_{0}_{1}", _x, _y);
                    File.WriteAllBytes(SavePath + fileName + ".png", bytes);
                    float posX = (x + currentWidth / 2f) / 100;
                    float posY = (y + currentHeight / 2f) / 100;
                    mapResData.AddBlock(fileName, _x, _y, currentWidth, currentHeight, posX + startPos.x,
                        posY + startPos.y);
                }
            }
        }

        if (IsLoop)
        {
            Dictionary<int, Dictionary<int, MapResBlockData>> mapBlockDic =
                new Dictionary<int, Dictionary<int, MapResBlockData>>();
            for (int i = 0; i < mapResData.ResBlockDataList.Count; i++)
            {
                if (!mapBlockDic.ContainsKey(mapResData.ResBlockDataList[i].X))
                {
                    mapBlockDic.Add(mapResData.ResBlockDataList[i].X, new Dictionary<int, MapResBlockData>());
                }

                if (!mapBlockDic[mapResData.ResBlockDataList[i].X].ContainsKey(mapResData.ResBlockDataList[i].Y))
                {
                    mapBlockDic[mapResData.ResBlockDataList[i].X].Add(mapResData.ResBlockDataList[i].Y, null);
                }

                mapBlockDic[mapResData.ResBlockDataList[i].X][mapResData.ResBlockDataList[i].Y] =
                    mapResData.ResBlockDataList[i];
            }

            List<MapResBlockData> mapResBlockData = new List<MapResBlockData>();
            for (int i = 0; i < cellMaxIndex.x; i++)
            {
                for (int j = 0; j < cellMaxIndex.y; j++)
                {
                    int newX = i % cellSize.x;
                    int newY = j % cellSize.y;
                    var orgBlockData = mapBlockDic[newX][newY];
                    float posX = (tileSize.x * (i) + (tileSize.x / 2f)) / 100f + startPos.x;
                    float posY = (tileSize.y * (j) + (tileSize.y / 2f)) / 100f + startPos.y;
                    MapResBlockData blockData = new MapResBlockData(orgBlockData.BlockName, i, j, orgBlockData.Width, orgBlockData.Height, posX, posY);
                    mapResBlockData.Add(blockData);
                }
            }

            mapResData.ResBlockDataList = mapResBlockData;
        }

        string jsonString = JsonConvert.SerializeObject(mapResData);
        //保存场景小图的信息配置
        string jsonFilePath = "Assets/GameRes/Map/MapConfig/" + $"mapImgData_{mapId}.json";
        File.WriteAllText(jsonFilePath, jsonString);
    }
    
    

}