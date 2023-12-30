using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeWeapon", menuName = "Upgrades/UpgradesAddWeapon/UpgradeAddSword")]
public class UpgradeAddSword : Upgrade
{
    public float damage;
    public GameObject prefabSword;
    public GameObject prefabSwordObject;
    public float attackRange;
    public float startFrequencyAttack;
    public Upgrade[] upgrades;

    public override void Action()
    {
        var sword = GameManager.player.AddComponent<Sword>();
        sword.Initialize(this);
    }
}
