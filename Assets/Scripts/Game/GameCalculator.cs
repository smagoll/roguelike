using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public static class GameCalculator
{
    public static Vector2 GetRandomDirection()
    {
        var angle = Random.Range(0, 360f);
        return GetDirectionOnTheAngle(angle);
    }

    public static Vector2 GetDirectionOnTheAngle(float angle)
    {
        float angleInRadians = angle * Mathf.Deg2Rad;
        Vector2 directionLocal = new Vector2(Mathf.Cos(angleInRadians), Mathf.Sin(angleInRadians));
        return directionLocal.normalized;
    }

    public static RareType GetRandomRareUpgrade()
    {
        var rnd = Random.Range(0, 100);

        if (rnd < 10)
            return RareType.Epic;
        if (rnd < 30)
            return RareType.Uncommon;
        if (rnd < 100)
            return RareType.Common;

        return RareType.Common;
    }
    
    public static string ConvertNumberToString(float number)
    {
        if (number > 1000f) return Math.Round(number / 1000f, 1) + "K";
        if (number > 1000000f) return Math.Round(number / 1000000f, 1) + "M";
        
        return Math.Round(number, 1).ToString();
    }
}
