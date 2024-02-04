using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AddZipZap", menuName = "Upgrades/Add/Abilities/ZipZap")]
public class UpgradeAddZipZap : UpgradeEquipment
{
    public float damage;
    public GameObject prefabLightning;
    public float distanceFlight;
    public float frequency;
    public float speedFlight;
    public int countLightnings;
    public float attackRange;
    public Upgrade[] upgrades;

    public override void Action()
    {
        var zipZap = GameManager.player.AddComponent<ZipZap>();
        zipZap.Initialize(this);
    }
}
