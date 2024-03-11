using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class HitController : MonoBehaviour
{
    private ObjectPool<DamageHurt> poolDefaultText;
    private ObjectPool<DamageHurt> poolSmallText;
    private ObjectPool<Evade> poolEvade;
    [SerializeField]
    private DamageHurt defaultText;
    [SerializeField]
    private DamageHurt smallText;
    [SerializeField]
    private Evade evade;
    [SerializeField]
    private Transform hitsTransform;

    private void Awake()
    {
        GlobalEventManager.CreateDamageHurt.AddListener(CreateDamageHurt);
        GlobalEventManager.CreateEvade.AddListener(CreateEvade);
        poolDefaultText = GameManager.CreatePool<DamageHurt>(defaultText, hitsTransform);
        poolSmallText = GameManager.CreatePool<DamageHurt>(smallText, hitsTransform);
        poolEvade = GameManager.CreatePool<Evade>(evade, hitsTransform);

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

    public void CreateEvade(Vector3 position)
    {
        var evadeObject = poolEvade.Get();
        evadeObject.transform.position = position;
        evadeObject.pool = poolEvade;
        evadeObject.Show();
    }
}
