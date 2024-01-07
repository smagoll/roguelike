using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : AbilityDynamic, IProjectileController
{
    public GameObject prefabFireBall;

    public float damage;
    public float rangeBlast;

    public float DistanceFlight { get; set; }

    public float SpeedFlight { get; set; }

    public override void Action()
    {
        var fireBall = Instantiate(prefabFireBall, transform.position, Quaternion.identity);
        var fireBallProjectile = fireBall.GetComponent<FireBallProjectile>();
        fireBallProjectile.projectileController = this;
        fireBallProjectile.fireBall = this;
        var direction = new Vector2(Random.Range(-1,1), Random.Range(-1, 1));
        fireBallProjectile.direction = direction;
    }

    public void Initialize(UpgradeAddFireball dataFireball)
    {
        Frequency = dataFireball.frequency;
        damage = dataFireball.damage;
        rangeBlast = dataFireball.rangeBlast;
        DistanceFlight = dataFireball.distanceFlight;
        SpeedFlight = dataFireball.speedFlight;
        prefabFireBall = dataFireball.prefabFireball;
        upgrades = dataFireball.upgrades;

        StartAttack();
    }
}
