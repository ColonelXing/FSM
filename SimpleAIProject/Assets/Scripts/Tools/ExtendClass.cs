using UnityEngine;

public static class ExtendClass
{
    public static T GetOrAdd<T>(this GameObject t) where T : Component
    {
        T component = t.GetComponent<T>();
        if (component == null)
        {
            component = t.AddComponent<T>();
        }
        return component;
    }

    public static T GetOrAdd<T>(this Transform t) where T : Component
    {
        return t.gameObject.GetOrAdd<T>();
    }

}

