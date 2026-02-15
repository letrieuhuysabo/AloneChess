using System;
using UnityEngine;

public static class Configs
{
    public static int currentLevel = 1;
    public static int levelQuantity = 6;
    public static bool FloatEqual(float a, float b)
    {
        return Mathf.Abs(a-b) < 0.001f;
    }
    public static bool Vector3Equal(Vector3 v1, Vector3 v2)
    {
        return FloatEqual(v1.x,v2.x) && FloatEqual(v1.y,v2.y);
    }
    public static Vector2Int ConvertVectorToInt(Vector3 v)
    {
        return new Vector2Int((int)Math.Round(v.x,0),(int)Math.Round(v.y,0));
    }
}
