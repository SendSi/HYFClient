using System.Collections.Generic;
using UnityEngine.Events;

public class EventCenter : Singleton<EventCenter>
{
    #region 事件无值 加监Bind   移监UnBind  发监Fire

    private readonly Dictionary<EventEnum, List<UnityAction>> eventNonDic =
        new Dictionary<EventEnum, List<UnityAction>>();

    public void Bind(EventEnum name, UnityAction action) //EventEnum 枚举
    {
        List<UnityAction> tAct = null;
        if (eventNonDic.TryGetValue(name, out tAct))
        {
            tAct.Add(action);
            eventNonDic[name] = tAct; //使用了  dic.TryGetValue()   必需重新赋值给字典
        }
        else
        {
            eventNonDic[name] = new List<UnityAction>() { action };
        }
    }

    public void Fire(EventEnum name)
    {
        List<UnityAction> tAct = null;
        if (eventNonDic.TryGetValue(name, out tAct))
        {
            for (int i = 0; i < tAct.Count; i++)
            {
                tAct[i]?.Invoke();
            }
        }
    }

    public void UnBind(EventEnum name, UnityAction action)
    {
        List<UnityAction> tAct = null;
        if (eventNonDic.TryGetValue(name, out tAct)) // 不能使用 dic.TryGetValue()  类似于被顶掉
        {
            for (int i = 0; i < tAct.Count; i++)
            {
                if (tAct[i] == action)
                {
                    tAct.RemoveAt(i);
                    break;
                }
            }

            eventNonDic[name] = tAct;
        }
    }

    #endregion

    #region 事件有值  加监Bind<T>   移监UnBind<T>  发监Fire<T>

    private readonly Dictionary<EventEnum, IEventAction> eventActionDic = new Dictionary<EventEnum, IEventAction>();

//--------------------------------一个值--飞---------------------------------
    public void Fire<T1>(EventEnum name, T1 obj)
    {
        IEventAction tAct = null;
        if (eventActionDic.TryGetValue(name, out tAct))
        {
            (tAct as EventOne<T1>)?.InvokeAct(obj);
        }
    }

    public void Bind<T1>(EventEnum name, UnityAction<T1> action)
    {
        IEventAction tAct = null;
        if (eventActionDic.TryGetValue(name, out tAct))
        {
            (tAct as EventOne<T1>)?.AddAct(action);
            eventActionDic[name] = tAct;
        }
        else
        {
            eventActionDic[name] = new EventOne<T1>(action); //构造函数有 add进去了
        }
    }

    public void UnBind<T1>(EventEnum name, UnityAction<T1> action)
    {
        IEventAction tAct = null;
        if (eventActionDic.TryGetValue(name, out tAct))
        {
            (tAct as EventOne<T1>)?.RemoveAct(action);
            eventActionDic[name] = tAct;
        }
    }

//--------------------------------两个值--飞---------------------------------
    public void Fire<T1, T2>(EventEnum name, T1 t1, T2 t2)
    {
        IEventAction tAct = null;
        if (eventActionDic.TryGetValue(name, out tAct))
        {
            (tAct as EventTwo<T1, T2>)?.InvokeAct(t1, t2);
        }
    }

    public void Bind<T1, T2>(EventEnum name, UnityAction<T1, T2> action)
    {
        IEventAction tAct = null;
        if (eventActionDic.TryGetValue(name, out tAct))
        {
            (tAct as EventTwo<T1, T2>)?.AddAct(action);
            eventActionDic[name] = tAct;
        }
        else
        {
            eventActionDic[name] = new EventTwo<T1, T2>(action);
        }
    }

    public void UnBind<T1, T2>(EventEnum name, UnityAction<T1, T2> action)
    {
        IEventAction tAct = null;
        if (eventActionDic.TryGetValue(name, out tAct))
        {
            (tAct as EventTwo<T1, T2>)?.RemoveAct(action);
            eventActionDic[name] = tAct;
        }
    }

//--------------------------------三个值--飞---------------------------------
    public void Fire<T1, T2, T3>(EventEnum name, T1 t1, T2 t2, T3 t3)
    {
        IEventAction tAct = null;
        if (eventActionDic.TryGetValue(name, out tAct))
        {
            (tAct as EventThree<T1, T2, T3>)?.InvokeAct(t1, t2, t3);
        }
    }

    public void Bind<T1, T2, T3>(EventEnum name, UnityAction<T1, T2, T3> action)
    {
        IEventAction tAct = null;
        if (eventActionDic.TryGetValue(name, out tAct))
        {
            (tAct as EventThree<T1, T2, T3>)?.AddAct(action);
            eventActionDic[name] = tAct;
        }
        else
        {
            eventActionDic[name] = new EventThree<T1, T2, T3>(action);
        }
    }
    public void UnBind<T1, T2, T3>(EventEnum name, UnityAction<T1, T2, T3> action)
    {
        IEventAction tAct = null;
        if (eventActionDic.TryGetValue(name, out tAct))
        {
            (tAct as EventThree<T1, T2, T3>)?.RemoveAct(action);
            eventActionDic[name] = tAct;
        }
    }

    #endregion

    public void Clear()
    {
        eventActionDic.Clear();
        eventNonDic.Clear();
    }
}
