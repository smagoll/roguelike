using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : EquipmentDynamic, IProjectileController
{
    public GameObject prefabFireBall;

    public float damage;
    public float scaleExplosionRadius;
    private float explosionRadius;

    public float DistanceFlight { get; set; }

    public float SpeedFlight { get; set; }
    public Vector2 Direction { get; set; }

    public float ExplosionRadius { get => explosionRadius * scaleExplosionRadius / 100; set => explosionRadius = value; }

    public override void Action()
    {
        var fireBall = Instantiate(prefabFireBall, transform.position, Quaternion.identity);
        var fireBallProjectile = fireBall.GetComponent<FireBallProjectile>();
        fireBallProjectile.projectileController = this;
        fireBallProjectile.fireBall = this;
        fireBallProjectile.direction = GameCalculator.GetRandomDirection();
    }

    public void Initialize(UpgradeAddFireball dataFireball)
    {
        Frequency = dataFireball.frequency;
        damage = dataFireball.damage;
        explosionRadius = dataFireball.rangeBlast;
        DistanceFlight = dataFireball.distanceFlight;
        SpeedFlight = dataFireball.speedFlight;
        prefabFireBall = dataFireball.prefabFireball;
        upgrades = dataFireball.upgrades;

        isAttack = true;
    }
}
