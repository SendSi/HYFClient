using System.Collections.Generic;
using UnityEngine.Events;

public interface IEventAction
{
}

public class EventOne<T1> : IEventAction
{
    public List<UnityAction<T1>> actions;

    public EventOne(UnityAction<T1> action)
    {
        if (actions == null)
        {
            actions = new List<UnityAction<T1>>();
        }

        actions.Add(action);
    }

    public void AddAct(UnityAction<T1> action)
    {
        if (actions != null)
        {
            actions.Add(action);
        }
    }

    public void InvokeAct(T1 obj)
    {
        if (actions != null)
        {
            for (int i = 0; i < actions.Count; i++)
            {
                actions[i]?.Invoke(obj);
            }
        }
    }

    public void RemoveAct(UnityAction<T1> action)
    {
        if (actions != null)
        {
            for (int i = 0; i < actions.Count; i++)
            {
                if (actions[i] == action)
                {
                    actions.RemoveAt(i);
                    break;
                }
            }
        }
    }
}

public class EventTwo<T1, T2> : IEventAction
{
    public List<UnityAction<T1, T2>> actions;

    public EventTwo(UnityAction<T1, T2> action)
    {
        if (actions == null)
        {
            actions = new List<UnityAction<T1, T2>>();
        }

        actions.Add(action);
    }
    public void AddAct(UnityAction<T1,T2> action)
    {
        if (actions != null)
        {
            actions.Add(action);
        }
    }

    public void InvokeAct(T1 obj,T2 obj2)
    {
        if (actions != null)
        {
            for (int i = 0; i < actions.Count; i++)
            {
                actions[i]?.Invoke(obj,obj2);
            }
        }
    }

    public void RemoveAct(UnityAction<T1,T2> action)
    {
        if (actions != null)
        {
            for (int i = 0; i < actions.Count; i++)
            {
                if (actions[i] == action)
                {
                    actions.RemoveAt(i);
                    break;
                }
            }
        }
    }
}


public class EventThree<T1, T2,T3> : IEventAction
{
    public List<UnityAction<T1, T2,T3>> actions;

    public EventThree(UnityAction<T1, T2,T3> action)
    {
        if (actions == null)
        {
            actions = new List<UnityAction<T1, T2,T3>>();
        }

        actions.Add(action);
    }
    public void AddAct(UnityAction<T1,T2,T3> action)
    {
        if (actions != null)
        {
            actions.Add(action);
        }
    }

    public void InvokeAct(T1 obj,T2 obj2,T3 obj3)
    {
        if (actions != null)
        {
            for (int i = 0; i < actions.Count; i++)
            {
                actions[i]?.Invoke(obj,obj2,obj3);
            }
        }
    }

    public void RemoveAct(UnityAction<T1,T2,T3> action)
    {
        if (actions != null)
        {
            for (int i = 0; i < actions.Count; i++)
            {
                if (actions[i] == action)
                {
                    actions.RemoveAt(i);
                    break;
                }
            }
        }
    }
}
