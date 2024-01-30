using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicWandSphere : Weapon, IProjectileController
{
    public GameObject prefabProjectile;
    [HideInInspector]
    public float attackRange;

    public float DistanceFlight { get; set; }
    public float SpeedFlight { get; set; }
    public Vector2 Direction { get; set; }

    public override void Action()
    {
        Direction = GameManager.GetDirectionToCloseEnemy(transform, attackRange);
        var projectileObject = Instantiate(prefabProjectile, gameObject.transform.position, Quaternion.identity);
        var projectile = projectileObject.GetComponent<MagicWandProjectile>();
        projectile.direction = Direction;
        projectile.projectileController = this;
        projectile.damage = Damage;

        if (Direction == Vector2.zero)
            projectile.direction = GameCalculator.GetRandomDirection();
        else
            projectile.direction = Direction;

    }

    public void Initialize(float speedFlight, float distanceFlight, float frequency, float damage, float attackRange)
    {
        SpeedFlight = speedFlight;
        DistanceFlight = distanceFlight;
        Frequency = frequency;
        Damage = damage;
        this.attackRange = attackRange;

        isAttack = true;
    }
}
