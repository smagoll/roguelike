using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EffectManager : MonoBehaviour
{
    public static EffectManager instance;

    [SerializeField]
    private Transform effectTransform;
    [Header("Gravity")]
    [SerializeField]
    private GameObject gravityExplosion;
    [SerializeField]
    private GameObject prefabGravityEffect;

    [Header("Fireball")]
    [SerializeField]
    private GameObject fireballExplosion;
    [SerializeField]
    private float scaleExplosion;

    [Header("Hit")]
    [SerializeField]
    private GameObject hit;

    [Header("Others")]
    [SerializeField]
    private GameObject stoneExplosion;

    private ObjectPool<GameObject> poolGravityExplosion;
    private ObjectPool<GameObject> poolFireballExplosion;
    private ObjectPool<GameObject> poolStoneExplosion;
    private ObjectPool<GameObject> poolHit;



    private void Awake()
    {
        if (instance == null) instance = this;

        poolFireballExplosion = CreatePool(fireballExplosion);
        poolGravityExplosion = CreatePool(gravityExplosion);
        poolStoneExplosion = CreatePool(stoneExplosion);
        poolHit = CreatePool(hit);
    }

    public void CreateGravityExplosion(Transform transform)
    {
        var explosion = poolGravityExplosion.Get();
        explosion.transform.position = transform.position;
    }
    
    public void CreateStoneExplosion(Transform transform)
    {
        var explosion = poolStoneExplosion.Get();
        explosion.transform.position = transform.position;
    }
    
    public void CreateFireballExplosion(Transform transform)
    {
        var explosion = poolFireballExplosion.Get();
        explosion.transform.position = transform.position;
        var fireBallController = GameManager.player.GetComponent<FireBall>();
        explosion.transform.localScale = new Vector3(scaleExplosion, scaleExplosion, scaleExplosion) * fireBallController.scaleExplosionRadius / 100;
    }
    
    public void CreateHit(Transform transform)
    {
        var hitEffect = poolHit.Get();
        hitEffect.transform.position = transform.position;
    }

    public GameObject CreateGravityEffect(Transform transform)
    {
        return Instantiate(prefabGravityEffect, transform);
    }

    private ObjectPool<GameObject> CreatePool(GameObject gameObject)
    {
        ObjectPool<GameObject> pool = new(() =>
        {
            return Instantiate(gameObject, effectTransform);
        }, obj => {
            obj.gameObject.SetActive(true);
        }, obj => {
            obj.gameObject.SetActive(false);
        }, obj => {
            Destroy(obj);
        }, false);

        return pool;
    }
}
