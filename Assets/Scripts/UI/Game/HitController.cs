using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class HitController : MonoBehaviour
{
    [SerializeField]
    private DamageHurt defaultText;
    [SerializeField]
    private DamageHurt smallText;
    [SerializeField]
    private Transform hitsTransform;

    private void Awake()
    {
        GlobalEventManager.CreateDamageHurt.AddListener(CreateDamageHurt);


    }

    private void CreateDamageHurt(Vector3 position, float damage, TextHit textHit)
    {
        DamageHurt textHitPrefab = defaultText;

        switch (textHit)
        {
            case TextHit.Default:
                textHitPrefab = defaultText;
                break;
            case TextHit.Small:
                textHitPrefab = smallText;
                break;
        }

        var damageHurt = Instantiate(textHitPrefab, position, Quaternion.identity, hitsTransform);
        damageHurt.GetComponent<DamageHurt>().damage = damage;
    }
}
