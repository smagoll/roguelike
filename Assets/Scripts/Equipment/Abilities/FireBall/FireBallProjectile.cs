using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class FireBallProjectile : Projectile
{
    public ObjectPool<FireBallProjectile> pool;
    public FireBall fireBall;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            DestroyProjectile();
        }
    }

    public override void DestroyProjectile()
    {
        var enemies = Physics2D.OverlapCircleAll(transform.position, fireBall.ExplosionRadius, GameManager.layerEnemy);
        if (enemies.Length > 0)
        {
            foreach (var enemy in enemies)
            {
                enemy.GetComponent<Enemy>().TakeDamage(fireBall.damage);
            }
        }
        EffectManager.instance.CreateFireballExplosion(transform);
        AudioGame.instance.PlayMainSFX(AudioGame.instance.fireballExplosion);
        pool.Release(this);
    }
}
