using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Field : MonoBehaviour
{
    public MagneticField controller;
    public float lastTimeAttack = 0f;
    public List<GameObject> enemies = new();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            enemies.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            enemies.Remove(collision.gameObject);
        }
    }

    private void Update()
    {
        var enemiesCopy = new List<GameObject>(enemies);
        if (Time.time - lastTimeAttack > controller.Frequency)
        {
            lastTimeAttack = Time.time;

            if (enemiesCopy.Count == 0)
                return;

            foreach (var enemy in enemiesCopy)
            {
                enemy.GetComponent<Enemy>().TakeDamage(controller.damage);
            }
        }
    }
}
