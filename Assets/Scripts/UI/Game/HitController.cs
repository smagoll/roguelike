using UnityEngine;

public class HitController : MonoBehaviour
{
    [SerializeField]
    private GameObject defaultText;
    [SerializeField]
    private GameObject smallText;

    private void Awake()
    {
        GlobalEventManager.CreateDamageHurt.AddListener(CreateDamageHurt);
    }

    private void CreateDamageHurt(Vector3 position, float damage, TextHit textHit)
    {
        GameObject textHitPrefab = defaultText;

        switch (textHit)
        {
            case TextHit.Default:
                textHitPrefab = defaultText;
                break;
            case TextHit.Small:
                textHitPrefab = smallText;
                break;
        }

        var damageHurt = Instantiate(textHitPrefab, position, Quaternion.identity);
        damageHurt.GetComponent<DamageHurt>().damage = damage;
    }
}
