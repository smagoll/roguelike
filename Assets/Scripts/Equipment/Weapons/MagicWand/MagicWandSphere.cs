using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicWandSphere : MonoBehaviour, IProjectileController
{
    public GameObject prefabProjectile;
    [HideInInspector]
    private MagicWand magicWand;
    public bool isAttack = false;
    private float lastTimeAttack = 0f;

    public float DistanceFlight { get; set; }
    public float SpeedFlight { get; set; }
    public Vector2 Direction { get; set; }

    private void Update()
    {
        if (isAttack)
        {
            if (Time.time - lastTimeAttack >= magicWand.Frequency)
            {
                Action();
                lastTimeAttack = Time.time;
            }
        }
    }

    public void Action()
    {
        Direction = GameManager.GetDirectionToCloseEnemy(transform, magicWand.attackRange);
        var projectileObject = Instantiate(prefabProjectile, gameObject.transform.position, Quaternion.identity);
        var projectile = projectileObject.GetComponent<MagicWandProjectile>();
        projectile.direction = Direction;
        projectile.projectileController = this;
        projectile.damage = magicWand.Damage;

        if (Direction == Vector2.zero)
            projectile.direction = GameCalculator.GetRandomDirection();
        else
            projectile.direction = Direction;

    }

    public void Initialize(MagicWand magicWand)
    {
        this.magicWand = magicWand;
        SpeedFlight = magicWand.speedFlight;
        DistanceFlight = magicWand.distanceFlight;

        isAttack = true;
    }
}
