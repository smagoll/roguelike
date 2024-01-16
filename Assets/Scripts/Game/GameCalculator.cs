using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCalculator
{
    public static Vector2 GetRandomDirection()
    {
        var angle = Random.Range(0, 360f);
        float angleInRadians = angle * Mathf.Deg2Rad;
        Vector2 directionLocal = new Vector2(Mathf.Cos(angleInRadians), Mathf.Sin(angleInRadians));
        return directionLocal.normalized;
    }
}
