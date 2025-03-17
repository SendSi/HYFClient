using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public static class UnityPool
{
    private static readonly Dictionary<string, Queue<UnityEngine.Object>> _unity = new Dictionary<string, Queue<UnityEngine.Object>>();
#if UNITY_EDITOR
    static Transform _pool_content;
    public static Transform PoolContent
    {
        get
        {
            if (_pool_content == null)
            {
                _pool_content = new GameObject("[UnityPool]").transform;
                UnityEngine.Object.DontDestroyOnLoad(PoolContent);
            }
            return _pool_content;
        }
    }
    static Dictionary<string, Transform> _pool_location_content = new Dictionary<string, Transform>();
#endif
    public static void Init()
    {
        GameMain.Instance.AddLowMemory(Clear);
    }
    public static T Get<T>(string location, Func<T> create = null) where T : UnityEngine.Object
    {
        if (!_unity.TryGetValue(location, out var queue) || queue.Count == 0)
        {
            if (create != null)
            {
                return create.Invoke();
            }
            return null;
        }
        else
        {
            var obj = queue.Dequeue();
            if (obj is GameObject go)
            {
                go.Visible(true);
                go.transform.SetParent(null);
                SceneManager.MoveGameObjectToScene(go, SceneManager.GetActiveScene());
            }
            return obj as T;
        }
    }

    public static void Push(UnityEngine.GameObject obj)
    {
        if (obj == null)
        {
            Debug.LogError("将Null的UnityEngine.GameObject 放入了对象池!");
            return;
        }
        var mono = obj.GetComponent<ResHandleMono>();
        if (mono == null)
        {
#if UNITY_EDITOR
            throw new Exception("对象池添加了非ResHandleMono对象");
#else
            return;
#endif
        }
        var location = mono.Location;
        Push(location, obj);
    }

    public static void Push(string location, UnityEngine.Object obj)
    {
        if (obj == null)
        {
            Debug.LogError("将Null的UnityEngine.Object 放入了对象池!");
            return;
        }

        if (!_unity.TryGetValue(location, out var queue))
        {
            queue = new Queue<UnityEngine.Object>();
            _unity.Add(location, queue);
        }
#if UNITY_EDITOR
        if (queue.Contains(obj))
        {
            throw new Exception("对象池重复添加！请检查代码");
        }
#endif
        if (obj is GameObject go)
        {
//             var entityMono = go.GetComponent<EntityViewer>();
//             if (entityMono != null)
//             {
//                 UnityEngine.Object.Destroy(entityMono);
//             }
// #if UNITY_EDITOR
//             if (!_pool_location_content.TryGetValue(location, out var locationContent))
//             {
//                 locationContent = new GameObject($"[{location}]").transform;
//                 locationContent.SetParent(PoolContent);
//                 _pool_location_content.Add(location, locationContent);
//             }
//             go.transform.parent = locationContent;
// #else
//             go.transform.parent = null;
// #endif
            go.Visible(false);
        }
        queue.Enqueue(obj);
    }

    public static void Clear()
    {
        foreach (var kv in _unity)
        {
            foreach (var obj in kv.Value)
            {
                UnityEngine.Object.Destroy(obj);
            }
        }
        _unity.Clear();
    }

}
