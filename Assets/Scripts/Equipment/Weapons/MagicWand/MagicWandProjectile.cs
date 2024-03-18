using UnityEngine;
using UnityEngine.Pool;

public class MagicWandProjectile : Projectile
{
    [SerializeField]
    private TrailRenderer trailRenderer;
    public ObjectPool<MagicWandProjectile> pool;
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

    private void OnEnable()
    {
        isHit = false;
    }
    
    public void StartFlight()
    {
        UpdateProjectile();
        isFlight = true;
    }
    
    public override void DestroyProjectile()
    {
        trailRenderer.Clear();
        isFlight = false;
        pool.Release(this);
    }
}
