using System;
using UnityEngine;
using UnityEngine.Pool;

public class Arrow : Projectile
{
    public ObjectPool<Arrow> pool;
    public Bow bow;
    private bool isHit;
    public bool IsThrough { get; set; }
    [SerializeField]
    private TrailRenderer trailRenderer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isHit && !IsThrough)
            return;

        if (collision.CompareTag("Enemy"))
        {
            isHit = true;
            collision.GetComponent<Enemy>().TakeDamage(bow.Damage);

            if (!IsThrough)
                DestroyProjectile();
        }
    }

    public void Initialize(Bow bow, bool isThrough, ObjectPool<Arrow> pool)
    {
        this.bow = bow;
        projectileController = bow;
        IsThrough = isThrough;
        this.pool = pool;
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

    private void OnEnable()
    {
        isHit = false;
    }
}