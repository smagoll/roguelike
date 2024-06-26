using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AddZipZap", menuName = "Upgrades/Add/Abilities/ZipZap")]
public class UpgradeAddZipZap : UpgradeAbility
{
    public Lightning prefabLightning;
    public float distanceFlight;
    public float speedFlight;
    public int countLightnings;
    public float attackRange;
    public Upgrade[] upgrades;

    public override void Action()
    {
        var zipZap = GameManager.player.AddComponent<ZipZap>();
        foreach (var upgrade in upgrades) upgrade.objectUpgrade = this;
        zipZap.Initialize(this);
        GlobalEventManager.Start_AddItem(this);
    }
}
