using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "AddSword", menuName = "Upgrades/Add/Weapons/Sword")]
public class UpgradeAddSword : UpgradeWeapon
{
    [Header("Stats")]
    public GameObject prefabSword;
    public GameObject prefabSwordObject;
    public float attackRange;
    public float startFrequencyAttack;
    public Upgrade[] upgrades;

    public override void Action()
    {
        GlobalEventManager.Start_AddItem(this);
        var sword = GameManager.player.AddComponent<Sword>();
        foreach (var upgrade in upgrades) upgrade.objectUpgrade = this;
        sword.Initialize(this);
    }
}