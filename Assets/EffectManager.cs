using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EffectManager : MonoBehaviour
{
    [SerializeField]
    private GameObject gravityExplosion;
    [SerializeField]
    private GameObject hit;

    private void Awake()
    {
        EffectEventManager.createGravityExplosion.AddListener(CreatePoolExplosion);
        EffectEventManager.createHit.AddListener(CreateHit);
    }

    private void CreatePoolExplosion(Transform transform)
    {
        Instantiate(gravityExplosion, transform.position, Quaternion.identity);
    }
    
    private void CreateHit(Transform transform)
    {
        Instantiate(hit, transform.position, Quaternion.identity);
    }
}
