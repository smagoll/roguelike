using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class FireBall : EquipmentDynamic, IProjectileController
{
    private ObjectPool<FireBallProjectile> pool;
    public FireBallProjectile prefabFireBall;

    public float damage;
    public float scaleExplosionRadius = 100;
    private float explosionRadius;

    public float DistanceFlight { get; set; }

    public float SpeedFlight { get; set; }
    public Vector2 Direction { get; set; }

    public float ExplosionRadius { get => explosionRadius * scaleExplosionRadius / 100; set => explosionRadius = value; }

    private void Awake()
    {
        pool = GameManager.CreatePool<FireBallProjectile>(prefabFireBall);
    }

    public override void Action()
    {
        var fireBall = pool.Get();
        fireBall.transform.position = transform.position;
        fireBall.projectileController = this;
        fireBall.fireBall = this;
        fireBall.direction = GameCalculator.GetRandomDirection();
    }

    public void Initialize(UpgradeAddFireball dataFireball)
    {
        Frequency = dataFireball.Frequency;
        damage = dataFireball.Damage;
        explosionRadius = dataFireball.RadiusBlast;
        DistanceFlight = dataFireball.distanceFlight;
        SpeedFlight = dataFireball.speedFlight;
        prefabFireBall = dataFireball.prefabFireball;
        upgrades = dataFireball.upgrades;

        isAttack = true;
    }
}
