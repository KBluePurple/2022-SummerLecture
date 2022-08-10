using System;
using System.Linq;
using Random = UnityEngine.Random;

public static class Utills
{
    public static string GetRandomName(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, length)
          .Select(s => s[Random.Range(0, s.Length)]).ToArray());
    }

    public static T GetRandomEnum<T>() where T : System.Enum
    {
        var v = Enum.GetValues(typeof(T)); return (T)v.GetValue(Random.Range(0, v.Length));
    }
}
