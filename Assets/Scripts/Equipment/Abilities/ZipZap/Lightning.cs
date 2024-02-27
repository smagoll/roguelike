using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Pool;

public class Lightning : Projectile
{
    ObjectPool<Lightning> pool;
    public float damage;
    public float attackRange;
    private int sequence;
    private bool isHit = false;
    [SerializeField]
    private GameObject hit;
    public Transform trail;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isHit)
        {
            return;
        }

        if (collision.CompareTag("Enemy"))
        {
            isHit = true;
            sequence -= 1;
            
            collision.GetComponent<Enemy>().TakeDamage(damage);
            Instantiate(hit, transform.position, Quaternion.identity);
            AudioGame.instance.PlaySmallSFX(AudioGame.instance.lightningCharge);

            if (sequence <= 0)
            {
                DestroyProjectile();
            }

            direction = DirectionCloseEnemy(collision.gameObject);
            UpdateProjectile();
            UpdateRotation();
            isHit = false;
        }
    }

    private void OnEnable()
    {
        AudioGame.instance.PlaySmallSFX(AudioGame.instance.lightningCharge);
        isHit = false;
    }

    public void StartFlight()
    {
        UpdateProjectile();
        UpdateRotation();
        isFlight = true;
    }

    private void UpdateRotation()
    {
        trail.localEulerAngles = new Vector3(0, 0, -transform.eulerAngles.z);
    }

    public void Initialize(IProjectileController projectileController, float damage, int sequence, float attackRange, Vector2 direction, ObjectPool<Lightning> pool)
    {
        this.projectileController = projectileController;
        this.damage = damage;
        this.sequence = sequence;
        this.attackRange = attackRange;
        this.pool = pool;

        if (direction == Vector2.zero)
            this.direction = new Vector2(Random.Range(-1, 1), Random.Range(-1, 1));
        else
            this.direction = direction;
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

    public override void DestroyProjectile()
    {
        isFlight = false;
        pool.Release(this);
    }
}
