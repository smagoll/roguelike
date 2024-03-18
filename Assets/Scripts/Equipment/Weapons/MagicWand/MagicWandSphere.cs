using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class MagicWandSphere : MonoBehaviour, IProjectileController
{
    private ObjectPool<MagicWandProjectile> projectiles;
    
    public MagicWandProjectile prefabProjectile;
    [HideInInspector]
    private MagicWand magicWand;
    public bool isAttack = false;
    private float lastTimeAttack = 0f;

    public float DistanceFlight { get; set; }
    public float SpeedFlight { get; set; }
    public Vector2 Direction { get; set; }

    private void Awake()
    {
        projectiles = GameManager.CreatePool(prefabProjectile);
    }

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
        var projectile = projectiles.Get();
        projectile.transform.position = transform.position;
        
        projectile.direction = Direction;
        projectile.projectileController = this;
        projectile.magicWand = magicWand;
        projectile.pool = projectiles;

        if (Direction == Vector2.zero)
            projectile.direction = GameCalculator.GetRandomDirection();
        else
            projectile.direction = Direction;

        projectile.StartFlight();
    }

    public void Initialize(MagicWand magicWand)
    {
        this.magicWand = magicWand;
        SpeedFlight = magicWand.speedFlight;
        DistanceFlight = magicWand.distanceFlight;

        isAttack = true;
    }
}
