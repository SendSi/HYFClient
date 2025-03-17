using UnityEngine;

public static class GameObjectEx
{
    public static void Visible(this GameObject go, bool b)
    {
        if (go != null && go.activeInHierarchy != b)
        {
            go.SetActive(b);
        }
    }
    
    public static void SetParent(this GameObject go, GameObject parent, bool worldPositionStays = true)
    {
        go.transform.SetParent(parent.transform, worldPositionStays);
    }
    
    public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
    {
        var component = gameObject.GetComponent<T>();
        if (component == null)
        {
            component = gameObject.AddComponent<T>();
        }

        return component;
    }
}