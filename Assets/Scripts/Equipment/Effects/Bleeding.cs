using System.Collections;
using UnityEngine;

public class Bleeding : MonoBehaviour
{
    private float damagePerSecond;
    private float frequency;

    public float TimeBleeding { get; set; }

    public float Damage
    {
        set => damagePerSecond = value / 10f;
    }

    private void Start()
    {
        StartCoroutine(StartBleeding());
    }

    private IEnumerator StartBleeding()
    {
        while (TimeBleeding <= 0)
        {
            yield return new WaitForSeconds(frequency);
            GetComponent<Enemy>().TakeDamage(damagePerSecond, TextHit.Small);
            TimeBleeding--;
        }

        Destroy(gameObject);
    }
}
