using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Tornado : MonoBehaviour
{
    ObjectPool<Tornado> pool;

    public float damage;
    public float timeLife;
    public float frequencyChangeDirection;
    public float speedFlight;

    private float startTime;
    private float lastTimeChange = 0f;
    private Vector2 direction;

    private void OnEnable()
    {
        startTime = Time.time;
        direction = GameCalculator.GetRandomDirection();
    }

    private void Update()
    {
        CheckDestroy();
        if (Time.time - lastTimeChange > frequencyChangeDirection)
        {
            direction = GameCalculator.GetRandomDirection();
            lastTimeChange = Time.time;
        }
        Flight();
    }

    private void Flight()
    {
        transform.Translate(speedFlight * Time.deltaTime * direction);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().TakeDamage(damage);
        }
    }

    public void Initialize(float damage, float timeLife, float frequencyChange, float speedFlight, ObjectPool<Tornado> pool)
    {
        this.damage = damage;
        this.timeLife = timeLife;
        this.frequencyChangeDirection = frequencyChange;
        this.speedFlight = speedFlight;
        this.pool = pool;
    }

    private void CheckDestroy()
    {
        if (Time.time - startTime > timeLife)
        {
            pool.Release(this);
        }
    }
}
