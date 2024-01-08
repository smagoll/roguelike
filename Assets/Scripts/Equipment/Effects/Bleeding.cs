using UnityEngine;

public class Bleeding : MonoBehaviour
{
    private float damagePerSecond;
    private readonly float frequency = 0.5f;
    private float lastTimeTick;

    public float TimeBleeding { get; set; }

    public float Damage
    {
        set => damagePerSecond = value / 10f;
    }

    private void Start()
    {
        lastTimeTick = Time.time;
        TimeBleeding = 5f;
    }

    private void Update()
    {
        if (Time.time - lastTimeTick >= frequency)
        {
            GetComponent<Enemy>().TakeDamage(damagePerSecond, TextHit.Small);
            lastTimeTick = Time.time;
        }

        TimeBleeding -= Time.deltaTime;

        if (TimeBleeding <= 0)
        {
            Destroy(this);
        }
    }
}
