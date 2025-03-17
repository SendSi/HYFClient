using System;
using System.Collections.Generic;
using UnityEngine;

public static class Pool
{
    private static readonly Dictionary<Type, Queue<object>> _dict = new Dictionary<Type, Queue<object>>();
    public static object Get(Type type)
    {
        object obj;
        if (!_dict.TryGetValue(type, out Queue<object> queue))
        {
            obj = Activator.CreateInstance(type);
        }
        else if (queue.Count == 0)
        {
            obj = Activator.CreateInstance(type);
        }
        else
        {
            obj = queue.Dequeue();
        }

        return obj;
    }

    public static T Get<T>(Type type)
    {
        return (T)Get(type);
    }

    public static T Get<T>()
    {
        return Get<T>(typeof(T));
    }

    public static void Push(object obj)
    {
#if UNITY_EDITOR
        if (!Application.isPlaying)
        {
            return;
        }
#endif
        Type type = obj.GetType();
        if (!_dict.TryGetValue(type, out var queue))
        {
            queue = new Queue<object>();
            _dict.Add(type, queue);
        }
#if UNITY_EDITOR
        if (queue.Contains(obj))
        {
            throw new Exception("对象池重复添加！请检查代码");
        }
#endif
        queue.Enqueue(obj);
    }

    public static void Clear()
    {
        _dict.Clear();
    }
}
