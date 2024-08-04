using System.Collections.Generic;
using UnityEngine.Events;

public partial class EventCenter : Singleton<EventCenter>
{
    #region 事件无值 加监Bind   移监UnBind  发监Fire
    private readonly Dictionary<int, List<UnityAction>> eventNonDic = new Dictionary<int, List<UnityAction>>();

    public void Bind(int name, UnityAction action) //int 枚举
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

    public void Fire(int name)
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

    public void UnBind(int name, UnityAction action)
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
    private readonly Dictionary<int, IEventAction> eventActionDic = new Dictionary<int, IEventAction>();

//--------------------------------一个值--飞---------------------------------
    public void Fire<T1>(int name, T1 obj)
    {
        IEventAction tAct = null;
        if (eventActionDic.TryGetValue(name, out tAct))
        {
            (tAct as EventOne<T1>)?.InvokeAct(obj);
        }
    }

    public void Bind<T1>(int name, UnityAction<T1> action)
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

    public void UnBind<T1>(int name, UnityAction<T1> action)
    {
        IEventAction tAct = null;
        if (eventActionDic.TryGetValue(name, out tAct))
        {
            (tAct as EventOne<T1>)?.RemoveAct(action);
            eventActionDic[name] = tAct;
        }
    }

//--------------------------------两个值--飞---------------------------------
    public void Fire<T1, T2>(int name, T1 t1, T2 t2)
    {
        IEventAction tAct = null;
        if (eventActionDic.TryGetValue(name, out tAct))
        {
            (tAct as EventTwo<T1, T2>)?.InvokeAct(t1, t2);
        }
    }

    public void Bind<T1, T2>(int name, UnityAction<T1, T2> action)
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

    public void UnBind<T1, T2>(int name, UnityAction<T1, T2> action)
    {
        IEventAction tAct = null;
        if (eventActionDic.TryGetValue(name, out tAct))
        {
            (tAct as EventTwo<T1, T2>)?.RemoveAct(action);
            eventActionDic[name] = tAct;
        }
    }

//--------------------------------三个值--飞---------------------------------
    public void Fire<T1, T2, T3>(int name, T1 t1, T2 t2, T3 t3)
    {
        IEventAction tAct = null;
        if (eventActionDic.TryGetValue(name, out tAct))
        {
            (tAct as EventThree<T1, T2, T3>)?.InvokeAct(t1, t2, t3);
        }
    }

    public void Bind<T1, T2, T3>(int name, UnityAction<T1, T2, T3> action)
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

    public void UnBind<T1, T2, T3>(int name, UnityAction<T1, T2, T3> action)
    {
        IEventAction tAct = null;
        if (eventActionDic.TryGetValue(name, out tAct))
        {
            (tAct as EventThree<T1, T2, T3>)?.RemoveAct(action);
            eventActionDic[name] = tAct;
        }
    }
    
    
    //--------------------------------四个值--飞---------------------------------
    public void Fire<T1, T2, T3, T4>(int name, T1 t1, T2 t2, T3 t3, T4 t4)
    {
        IEventAction tAct = null;
        if (eventActionDic.TryGetValue(name, out tAct))
        {
            (tAct as EventFour<T1, T2, T3, T4>)?.InvokeAct(t1, t2, t3, t4);
        }
    }

    public void Bind<T1, T2, T3, T4>(int name, UnityAction<T1, T2, T3, T4> action)
    {
        IEventAction tAct = null;
        if (eventActionDic.TryGetValue(name, out tAct))
        {
            (tAct as EventFour<T1, T2, T3, T4>)?.AddAct(action);
            eventActionDic[name] = tAct;
        }
        else
        {
            eventActionDic[name] = new EventFour<T1, T2, T3, T4>(action);
        }
    }

    public void UnBind<T1, T2, T3, T4>(int name, UnityAction<T1, T2, T3, T4> action)
    {
        IEventAction tAct = null;
        if (eventActionDic.TryGetValue(name, out tAct))
        {
            (tAct as EventFour<T1, T2, T3, T4>)?.RemoveAct(action);
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