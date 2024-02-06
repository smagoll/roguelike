using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AddWindDance", menuName = "Upgrades/Add/Abilities/WindDance")]
public class UpgradeAddWindDance : UpgradeEquipment
{
    public GameObject prefabTornado;

    public float timeLifeTornado;
    public float speedFlight;
    public int countTornado;
    public float frequencyChangeDirection;

    public Upgrade[] upgrades;

    public override void Action()
    {
        var windDance = GameManager.player.AddComponent<WindDance>();
        windDance.Initialize(Damage, timeLifeTornado, Frequency, frequencyChangeDirection, speedFlight, countTornado, upgrades, prefabTornado);
    }
}
