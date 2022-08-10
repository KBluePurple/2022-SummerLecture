using System;
using Random = UnityEngine.Random;

public static class Extension
{
    public static T g<T>(this Type e) where T : Enum
    {
        var values=Enum.GetValues(e);return (T)values.GetValue(Random.Range(0, values.Length));
    }
}