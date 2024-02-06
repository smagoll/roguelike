using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZipZap : EquipmentDynamic, IProjectileController
{
    public float damage;
    public int countLightnings;
    public float attackRange;

    public float DistanceFlight { get; set; }
    public float SpeedFlight { get; set; }
    public Vector2 Direction { get; set; }

    public GameObject Lightning;

    public override void Action()
    {
        var lightningObject = Instantiate(Lightning, gameObject.transform.position, Quaternion.identity);
        var lightning = lightningObject.GetComponent<Lightning>();
        Direction = GameManager.GetDirectionToCloseEnemy(transform, attackRange);
        lightning.projectileController = this;
        lightning.Initialize(this, damage, Lightning, countLightnings, attackRange, Direction);
    }

    public void Initialize(UpgradeAddZipZap data)
    {
        damage = data.Damage;
        countLightnings = data.countLightnings;
        Lightning = data.prefabLightning;
        DistanceFlight = data.distanceFlight;
        SpeedFlight = data.speedFlight;
        Frequency = data.Frequency;
        upgrades = data.upgrades;
        attackRange = data.attackRange;

        isAttack = true;
    }
}
