using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Lightning : Projectile
{
    public float damage;
    public float attackRange;
    public GameObject prefabLightning;
    private int sequence;
    private bool isHit = false;
    public GameObject lastEnemy;

    public int Sequence
    {
        set
        {
            sequence = value;
            if (sequence <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isHit)
        {
            return;
        }

        if (collision.CompareTag("Enemy") && collision.gameObject != lastEnemy)
        {
            lastEnemy = collision.gameObject;
            isHit = true;
            var directionToNext = DirectionCloseEnemy(collision.gameObject);
            
            collision.GetComponent<Enemy>().TakeDamage(damage);

            var lightningObject = Instantiate(prefabLightning, gameObject.transform.position, Quaternion.identity);
            var lightning = lightningObject.GetComponent<Lightning>();
            lightning.Initialize(projectileController, damage, prefabLightning, sequence, attackRange, directionToNext);
            lightning.lastEnemy = lastEnemy;

            Destroy(gameObject);
        }
    }

    public void Initialize(IProjectileController projectileController, float damage, GameObject prefabLightning, int sequence, float attackRange, Vector2 direction)
    {
        this.projectileController = projectileController;
        this.damage = damage;
        this.prefabLightning = prefabLightning;
        Sequence = sequence - 1;
        this.attackRange = attackRange;

        if (direction == Vector2.zero)
        {
            this.direction = new Vector2(Random.Range(-1, 1), Random.Range(-1, 1));
        }
        else
        {
            this.direction = direction;
        }
    }

    private Vector2 DirectionCloseEnemy(GameObject currentEnemy)
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, 10f, GameManager.layerEnemy);
        var sortedEnemies = enemies.OrderBy(x => (transform.position - x.transform.position).sqrMagnitude).ToArray();

        foreach (var enemy in sortedEnemies)
        {
            if (enemy.gameObject != currentEnemy)
            {
                var heading = (enemy.transform.position - transform.position);
                var direction = heading / heading.magnitude;
                return direction;
            }
        }
        return Vector2.zero;
    }
}
