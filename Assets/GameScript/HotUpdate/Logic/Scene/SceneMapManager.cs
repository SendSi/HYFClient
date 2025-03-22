using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class SceneMapManager : Singleton<SceneMapManager>
{
    private bool _modifying = false;
    private MapResData _mapResData;
    private MapResBlockData[,] _mapResBlockDataArr;
    private List<MapBlockUnit> _blockUnitPool = new List<MapBlockUnit>();
    private List<MapBlockUnit> _mapBlockUnitList = new List<MapBlockUnit>();
    private bool _isLoadIng = false;
    private MapResLoadData _curLoadMapResData;
    private Queue<MapResLoadData> _mapResLoadDataQ = new Queue<MapResLoadData>();
    private Dictionary<string, Sprite> _spriteResDic = new Dictionary<string, Sprite>();

    /// <summary> 最大加载图片张数 </summary>
    private const int MaxMapResNum = 50;

    public GameObject Parent;

    public async UniTask Init(int mapId, bool backScene)
    {
        Parent = GameObject.Find("MapBlockParent");
        if (Parent == null)
        {
            Parent = new GameObject("MapBlockParent");
            Parent.transform.position = Vector3.zero;
        }
        GameObject.DontDestroyOnLoad(Parent);

        SceneCameraMgr.Instance.AddCameraRenderChangeEvent(RefreshScreenMapBlock);

        bool state = await ChangeMap(mapId, true);
        if (!state)
        {
            return;
        }
    }

    public async UniTask<bool> ChangeMap(int mapId, bool needRefresh = false)
    {
        _modifying = true;

        _mapResData = CfgJsonMgr.Instance.LoadConfigClass<MapResData>($"mapImgData_{mapId}");
        if (_mapResData == null)
        {
            return false;
        }

        _mapResBlockDataArr = new MapResBlockData[_mapResData.MaxX, _mapResData.MaxY];
        for (int i = 0; i < _mapResData.ResBlockDataList.Count; i++)
        {
            _mapResBlockDataArr[_mapResData.ResBlockDataList[i].X, _mapResData.ResBlockDataList[i].Y] = _mapResData.ResBlockDataList[i];
        }

        for (int i = 0; i < _blockUnitPool.Count; i++)
        {
            _blockUnitPool[i].Reset();
        }

        for (int i = 0; i < _mapBlockUnitList.Count; i++)
        {
            _mapBlockUnitList[i].Reset();
        }

        _curLoadMapResData = null;
        _isLoadIng = false;
        _mapResLoadDataQ.Clear();
        _spriteResDic.Clear();

        Vector4 bound = GetMapBound();
        SceneCameraMgr.Instance.SetBounds(bound.x, bound.y, bound.z, bound.w);
        _modifying = false;
        if (needRefresh)
        {
            RefreshScreenMapBlock();
        }

        return true;
    }

    public Vector4 GetMapBound()
    {
        Vector4 rect = new Vector4(_mapResData.StartX, _mapResData.StartY, _mapResData.EndX, _mapResData.EndY);
        return new Vector4(rect.x, rect.z, rect.y, rect.w);
    }

    List<MapResBlockData> _inScreenBlockDataList = new List<MapResBlockData>();
    List<MapResBlockData> _waitShowBlockDataList = new List<MapResBlockData>();

    void RefreshScreenMapBlock()
    {
        if (_modifying)
        {
            return;
        }
        _inScreenBlockDataList.Clear();
        Vector3 size = SceneCameraMgr.Instance.GetScreenBoundsInWorld(out Vector3 center);
        // Debug.LogError($"size={size}   center={center}");
        var list = GetInIsRectMapResBlockDataList(center, size + Vector3.one * 1);
        if (list != null)
        {
            for (int i = 0; i < list.Count; i++)
            {
                _inScreenBlockDataList.Add(list[i]);
            }
        }

        //生成这些图块
        RefreshBlockMapShow();
    }

    void RefreshBlockMapShow()
    {
        _waitShowBlockDataList.Clear();
        for (int i = 0; i < _mapBlockUnitList.Count; i++)
        {
            _blockUnitPool.Add(_mapBlockUnitList[i]);
        }
        _mapBlockUnitList.Clear();

        for (int i = 0; i < _inScreenBlockDataList.Count; i++)
        {
            if (i >= _blockUnitPool.Count)
            {
                var go = GetMapBlockGo();
                _blockUnitPool.Add(go);
            }
        }

        bool has = false;
        for (int i = 0; i < _inScreenBlockDataList.Count; i++)
        {
            has = false;
            for (int j = 0; j < _blockUnitPool.Count; j++)
            {
                if (_blockUnitPool[j].Equal(_inScreenBlockDataList[i]))
                {
                    _blockUnitPool[j].SetData(_inScreenBlockDataList[i]);
                    _mapBlockUnitList.Add(_blockUnitPool[j]);
                    _blockUnitPool.RemoveAt(j);
                    has = true;
                    break;
                }
            }

            if (!has)
            {
                _waitShowBlockDataList.Add(_inScreenBlockDataList[i]);
            }
        }
        for (int i = 0; i < _waitShowBlockDataList.Count; i++)
        {
            _blockUnitPool[0].SetData(_waitShowBlockDataList[i]);
            _mapBlockUnitList.Add(_blockUnitPool[0]);
            _blockUnitPool.RemoveAt(0);
        }

        for (int i = 0; i < _blockUnitPool.Count; i++)
        {
            _blockUnitPool[i].SetActive(false);
        }
    }

    public void GetSprite(MapBlockUnit unit, string spriteName)
    {
        if (_spriteResDic.TryGetValue(spriteName, out var value))
        {
            unit.SetSpriteRes(value, spriteName);
        }
        else
        {
            bool isAdd = false;
            if (_curLoadMapResData != null && _curLoadMapResData.SpriteName == spriteName)
            {
                _curLoadMapResData.MapBlockUnitList.Add(unit);
                isAdd = true;
            }

            if (isAdd == false)
            {
                foreach (var mapResLoadData in _mapResLoadDataQ)
                {
                    if (mapResLoadData.SpriteName == spriteName)
                    {
                        mapResLoadData.MapBlockUnitList.Add(unit);
                        isAdd = true;
                        break;
                    }
                }
            }

            if (isAdd == false)
            {
                var mapResLoadData = Pool.Get<MapResLoadData>();
                mapResLoadData.SpriteName = spriteName;
                mapResLoadData.MapBlockUnitList = new List<MapBlockUnit> { unit };
                _mapResLoadDataQ.Enqueue(mapResLoadData);
            }
            LoadSprite().Forget();
        }
    }

    MapBlockUnit GetMapBlockGo()
    {
        GameObject go = ResMgr.Instance.LoadAsset<GameObject>("MapBlockUnit");
        go.SetParent(Parent);
        return go.GetComponent<MapBlockUnit>();
    }

    private async UniTask LoadSprite()
    {
        if (_isLoadIng)
        {
            return;
        }
        _isLoadIng = true;
        Sprite loadSprite;
        if (_mapResLoadDataQ.Count > 0)
        {
            _curLoadMapResData = _mapResLoadDataQ.Dequeue();
            loadSprite = await ResMgr.Instance.LoadAssetAsync<Sprite>(_curLoadMapResData.SpriteName) as Sprite;
            if (_curLoadMapResData == null)
            {
                return; //说明转场景了
            }
            AddSpriteRes(_curLoadMapResData.SpriteName, loadSprite);
            for (int i = 0; i < _curLoadMapResData.MapBlockUnitList.Count; i++)
            {
                if (_curLoadMapResData.MapBlockUnitList[i] != null)
                {
                    _curLoadMapResData.MapBlockUnitList[i].SetSpriteRes(loadSprite, _curLoadMapResData.SpriteName);
                }
            }
            _curLoadMapResData.Reset();
            Pool.Push(_curLoadMapResData);
            _curLoadMapResData = null;
        }
        else
        {
            _isLoadIng = false;
            return;
        }

        _isLoadIng = false;
        await LoadSprite();
    }

    private List<string> _waitRemoveResSpriteList = new List<string>();

    private void AddSpriteRes(string resName, Sprite sprite)
    {
        _waitRemoveResSpriteList.Clear();
        _spriteResDic.TryAdd(resName, sprite);
        if (_spriteResDic.Count > MaxMapResNum)
        {
            Vector3 size = SceneCameraMgr.Instance.GetScreenBoundsInWorld(out Vector3 center);
            size += Vector3.one * 3;
            var list = GetInIsRectMapResBlockDataList(center, size);
            bool has = false;
            foreach (string key in _spriteResDic.Keys)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].BlockName == key)
                    {
                        has = true;
                        break;
                    }
                }

                if (!has)
                {
                    _waitRemoveResSpriteList.Add(key);
                }
            }

            for (int i = 0; i < _waitRemoveResSpriteList.Count; i++)
            {
                if (_spriteResDic.ContainsKey(_waitRemoveResSpriteList[i]))
                {
                    //todo 释放内存
                    _spriteResDic.Remove(_waitRemoveResSpriteList[i]);
                }
            }
            _waitRemoveResSpriteList.Clear();
        }
    }

    private List<MapResBlockData> GetInIsRectMapResBlockDataList(Vector3 center, Vector2 size)
    {
        if (_mapResData == null)
        {
            return null;
        }
        List<MapResBlockData> _inRectBlockDataList = new List<MapResBlockData>();
        List<MapResBlockData> _needCheckBlockDataList = new List<MapResBlockData>();
        List<MapResBlockData> _checkEndBlockDataList = new List<MapResBlockData>();

        int indexX = PosChangePointIndex(center, out int indexY);
        Debug.LogError($"indexX={indexX}  indexY={indexY}");
        if (indexX >= 0 && indexY >= 0 && _mapResBlockDataArr.GetLength(0) > indexX && _mapResBlockDataArr.GetLength(1) > indexY && _mapResBlockDataArr[indexX, indexY] != null)
        {
            var pointData = _mapResBlockDataArr[indexX, indexY];
            _needCheckBlockDataList.Add(_mapResBlockDataArr[pointData.X, pointData.Y]);
            _inRectBlockDataList.Add(_mapResBlockDataArr[pointData.X, pointData.Y]);
        }

        //向四周遍历，直到没有被相机看到的区域
        while (_needCheckBlockDataList.Count > 0)
        {
            var curBlockData = _needCheckBlockDataList[0];
            _needCheckBlockDataList.RemoveAt(0);
            _checkEndBlockDataList.Add(curBlockData);
            List<MapResBlockData> list = GetAroundResBlockList(curBlockData);
            // 如果与相机相交则加入显示列表，并加入待查找列表
            for (int i = 0; i < list.Count; i++)
            {
                //如果在待查找列表或已查找过的列表，则放弃检测
                if (_needCheckBlockDataList.Contains(list[i]) || _checkEndBlockDataList.Contains(list[i]))
                {
                    continue;
                }

                if (SceneCameraMgr.Instance.IsRectanglesIntersect(center, size, new Vector3(list[i].PosX, list[i].PosY, 0), new Vector2(list[i].Width / 100f, list[i].Height / 100f)))
                {
                    bool inScreen = _inRectBlockDataList.Contains(list[i]);
                    if (!inScreen)
                    {
                        _inRectBlockDataList.Add(list[i]);
                    }
                    // 加入查找列表
                    bool isInCheckEnd = _checkEndBlockDataList.Contains(list[i]);
                    if (!isInCheckEnd)
                    {
                        _needCheckBlockDataList.Add(list[i]);
                    }
                }
            }
        }

        return _inRectBlockDataList;
    }

    List<MapResBlockData> _findList = new List<MapResBlockData>();

    List<MapResBlockData> GetAroundResBlockList(MapResBlockData center)
    {
        _findList.Clear();
        // 遍历周围8个格子
        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                // 计算周围格子的索引
                int newRow = center.X + i;
                int newColumn = center.Y + j;

                // 检查索引是否在数组边界内且不是中心格子
                if (newRow >= 0 && newRow < _mapResData.MaxX && newColumn >= 0 && newColumn < _mapResData.MaxY && !(i == 0 && j == 0))
                {
                    _findList.Add(_mapResBlockDataArr[newRow, newColumn]);
                }
            }
        }

        return _findList;
    }

    int PosChangePointIndex(Vector3 pos, out int y)
    {
        pos.x -= _mapResData.StartX;
        pos.y -= _mapResData.StartY;
        int x = Mathf.FloorToInt(pos.x * 100 / _mapResData.Width);
        y = Mathf.FloorToInt(pos.y * 100 / _mapResData.Height);
        return x;
    }

    protected override void OnDispose()
    {
        base.OnDispose();
        SceneCameraMgr.Instance.RemoveCameraRenderChangeEvent(RefreshScreenMapBlock);
    }

    public void Test()
    {
        var a1 = _mapResBlockDataArr.GetLength(0);
        var a2 = _mapResBlockDataArr.GetLength(1);

        Debug.LogError($"a1={a1}  a2={a2}");
    }
}