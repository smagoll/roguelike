using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Pool;

public class EffectEventManager
{
    public static UnityEvent<Transform> createGravityExplosion = new();
    public static UnityEvent<Transform> createHit = new();


    public static void Start_CreateGravityExplosion(Transform transform)
    {
        createGravityExplosion.Invoke(transform);
    }
    
    public static void Start_CreateHit(Transform transform)
    {
        createHit.Invoke(transform);
        //AudioGame.instance.PlaySFX(AudioGame.instance.hit);
    }
}
