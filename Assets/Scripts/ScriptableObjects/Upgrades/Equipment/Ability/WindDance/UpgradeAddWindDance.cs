using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AddWindDance", menuName = "Upgrades/Add/Abilities/WindDance")]
public class UpgradeAddWindDance : UpgradeAbility
{
    public Tornado prefabTornado;

    public float timeLifeTornado;
    public float speedFlight;
    public int countTornado;
    public float frequencyChangeDirection;

    public Upgrade[] upgrades;

    public override void Action()
    {
        var windDance = GameManager.player.AddComponent<WindDance>();
        foreach (var upgrade in upgrades) upgrade.objectUpgrade = this;
        windDance.Initialize(Damage, timeLifeTornado, Frequency, frequencyChangeDirection, speedFlight, countTornado, upgrades, prefabTornado);
        GlobalEventManager.Start_AddItem(this);
    }
}
