using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AddMagneticField", menuName = "Upgrades/Add/Abilities/MagneticField")]
public class UpgradeAddField : UpgradeAbility
{
    public GameObject prefabField;
    public float damage;
    public float frequency;
    public Upgrade[] upgrades;

    public override void Action()
    {
        var field = GameManager.player.AddComponent<MagneticField>();
        field.Initialize(this);
        GlobalEventManager.Start_AddItem(this);
    }
}
