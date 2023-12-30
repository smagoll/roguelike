using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeWeapon", menuName = "Upgrades/UpgradesAddWeapon/UpgradeAddBow")]
public class UpgradeAddBow : Upgrade
{
    public float damage;
    public GameObject prefabSword;
    public float attackRange;
    public float distanceFlight;
    public float startFrequencyAttack;
    public float speedFlightArrow;
    public Upgrade[] upgrades;

    public override void Action()
    {
        var bow = GameManager.player.AddComponent<Bow>();
        bow.Initialaze(this);
    }
}
