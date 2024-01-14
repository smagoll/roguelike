using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : EquipmentDynamic, IProjectileController
{
    public GameObject prefabFireBall;

    public float damage;
    public float rangeBlast;

    public float DistanceFlight { get; set; }

    public float SpeedFlight { get; set; }
    public Vector2 Direction { get; set; }

    public override void Action()
    {
        var fireBall = Instantiate(prefabFireBall, transform.position, Quaternion.identity);
        var fireBallProjectile = fireBall.GetComponent<FireBallProjectile>();
        fireBallProjectile.projectileController = this;
        fireBallProjectile.fireBall = this;
        fireBallProjectile.direction = new Vector2(Random.Range(-1,1), Random.Range(-1, 1));
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

        isAttack = true;
    }
}
