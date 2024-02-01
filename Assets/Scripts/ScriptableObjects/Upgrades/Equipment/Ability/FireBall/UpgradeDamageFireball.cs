using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Damage", menuName = "Upgrades/Abilities/Fireball/Damage")]
public class UpgradeDamageFireball : UpgradeStats
{
    public float damage;

    public override void Action()
    {
        GameManager.player.GetComponent<FireBall>().damage += damage;
    }
}