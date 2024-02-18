using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ZipZap : EquipmentDynamic, IProjectileController
{
    private ObjectPool<Lightning> pool;
    public float damage;
    public int countLightnings;
    public float attackRange;

    public float DistanceFlight { get; set; }
    public float SpeedFlight { get; set; }
    public Vector2 Direction { get; set; }

    public override void Action()
    {
        var lightning = pool.Get();
        Direction = GameManager.GetDirectionToCloseEnemy(transform, attackRange);
        lightning.projectileController = this;
        lightning.transform.position = transform.position;
        lightning.Initialize(this, damage, countLightnings, attackRange, Direction, pool);
    }

    public void Initialize(UpgradeAddZipZap data)
    {
        damage = data.Damage;
        countLightnings = data.countLightnings;
        DistanceFlight = data.distanceFlight;
        SpeedFlight = data.speedFlight;
        Frequency = data.Frequency;
        upgrades = data.upgrades;
        attackRange = data.attackRange;

        pool = GameManager.CreatePool<Lightning>(data.prefabLightning);

        isAttack = true;
    }
}
