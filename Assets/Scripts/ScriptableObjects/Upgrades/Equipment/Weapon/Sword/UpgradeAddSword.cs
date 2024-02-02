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

    public float Damage => stats.FirstOrDefault(x => x.type == StatType.damage).value + stats.FirstOrDefault(x => x.type == StatType.damage).step * (Level - 1);
    public float Frequency => stats.FirstOrDefault(x => x.type == StatType.frequency).value - stats.FirstOrDefault(x => x.type == StatType.frequency).step * (Level - 1);

    public override void Action()
    {
        var sword = GameManager.player.AddComponent<Sword>();
        sword.Initialize(this);
    }
}