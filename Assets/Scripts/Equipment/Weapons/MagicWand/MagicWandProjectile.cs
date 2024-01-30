using UnityEngine;

public class MagicWandProjectile : Projectile
{
    public float damage;
    private bool isHit = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isHit)
            return;

        if (collision.CompareTag("Enemy"))
        {
            isHit = true;
            collision.GetComponent<Enemy>().TakeDamage(damage);

            DestroyProjectile();
        }
    }
}
