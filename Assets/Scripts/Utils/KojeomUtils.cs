using System;
using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// C++ const 키워드를 흉내낸 구조체.
/// </summary>
/// <typeparam name="T"></typeparam>
public struct Const<T>
{
    public T Value { get; private set; }
    public Const(T value) : this()
    {
        this.Value = value;
    }
}

public static class KojeomUtils
{
    private static System.Random _systemRand = new System.Random(0);
    // ref : https://stackoverflow.com/questions/16100/how-should-i-convert-a-string-to-an-enum-in-c
    // ref : https://docs.microsoft.com/en-us/dotnet/api/system.enum.tryparse?redirectedfrom=MSDN&view=netframework-4.7.2#overloads
    public static T StringToEnum<T>(string value, bool ignoreCase = true)
    {
        return (T)Enum.Parse(typeof(T), value, ignoreCase);
    }

    public static string EnumToString<T>(T value)
    {
        return value.ToString();
    }

    public static Vector3Int ConvertVecToVecInt(Vector3 vec)
    {
        return new Vector3Int((int)vec.x, (int)vec.y, (int)vec.z);
    }

    public static Vector3 ConvertVecIntToVec(Vector3Int vec)
    {
        return new Vector3((float)vec.x, (float)vec.y, (float)vec.z);
    }

    public static bool StringToBool(string str)
    {
        bool ret = false;
        if (str.Equals("false", StringComparison.OrdinalIgnoreCase)) ret = false;
        else if (str.Equals("true", StringComparison.OrdinalIgnoreCase)) ret = true;

        return ret;
    }

    public static Vector2 GetCurve2DPoint(Vector2 start, Vector2 mid, Vector2 end, float t)
    {
        return ((1 - t) * (1 - t) * start) + (2 * t * (1 - t) * mid) + (t * t * end);
    }

   
    public static float RandomFloat(float min, float max, int seed = 0)
    {
        Random.InitState(seed);
        return Random.Range(min, max);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="min">Include</param>
    /// <param name="max">Exclusive</param>
    /// <param name="seed"></param>
    /// <returns></returns>
    public static int RandomInteger(int min, int max, int seed = 0)
    {
        Random.InitState(seed);
        return Random.Range(min, max);
    }

    public static bool RandomBool(int seed = 0)
    {
        if (seed != 0) { _systemRand = new System.Random(seed); }

        return _systemRand.Next() > (Int32.MaxValue / 2);
    }

    /// <summary>
    /// 유니티 엔진이 아닌 .Net 프레임워크 랜덤 이용.
    /// </summary>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    public static int DotNet_RandomInt(int min, int max, int seed = 0)
    {
        if(seed != 0) { _systemRand = new System.Random(seed); }

        return _systemRand.Next(min, max);
    }
}
