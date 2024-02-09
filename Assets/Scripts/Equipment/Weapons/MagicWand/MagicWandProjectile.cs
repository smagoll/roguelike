using UnityEngine;

public class MagicWandProjectile : Projectile
{
    public MagicWand magicWand;
    private bool isHit = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isHit)
            return;

        if (collision.CompareTag("Enemy"))
        {
            isHit = true;
            collision.GetComponent<Enemy>().TakeDamage(magicWand.Damage, magicWand.effectControllers.ToArray());

            DestroyProjectile();
        }
    }
}
