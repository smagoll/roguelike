using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EffectManager : MonoBehaviour
{
    [SerializeField]
    private GameObject gravityExplosion;

    private void Awake()
    {
        EffectEventManager.createGravityExplosion.AddListener(CreatePoolExplosion);
    }

    private void CreatePoolExplosion(Transform transform)
    {
        Instantiate(gravityExplosion, transform.position, Quaternion.identity);
    }
}
