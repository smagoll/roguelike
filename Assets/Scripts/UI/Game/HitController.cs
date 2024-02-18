using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class HitController : MonoBehaviour
{
    private ObjectPool<DamageHurt> poolDefaultText;
    private ObjectPool<DamageHurt> poolSmallText;
    [SerializeField]
    private DamageHurt defaultText;
    [SerializeField]
    private DamageHurt smallText;
    [SerializeField]
    private Transform hitsTransform;

    private void Awake()
    {
        GlobalEventManager.CreateDamageHurt.AddListener(CreateDamageHurt);
        poolDefaultText = GameManager.CreatePool<DamageHurt>(defaultText, hitsTransform);
        poolSmallText = GameManager.CreatePool<DamageHurt>(smallText, hitsTransform);

    }

    private void CreateDamageHurt(Vector3 position, float damage, TextHit textHit)
    {
        ObjectPool<DamageHurt> pool = poolDefaultText;

        switch (textHit)
        {
            case TextHit.Default:
                pool = poolDefaultText;
                break;
            case TextHit.Small:
                pool = poolSmallText;
                break;
        }

        var damageHurt = pool.Get();
        damageHurt.transform.position = position;
        damageHurt.damage = damage;
        damageHurt.pool = pool;
        damageHurt.Show();
    }
}
