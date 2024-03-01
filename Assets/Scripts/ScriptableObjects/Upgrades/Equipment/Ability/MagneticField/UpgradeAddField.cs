using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "AddMagneticField", menuName = "Upgrades/Add/Abilities/MagneticField")]
public class UpgradeAddField : UpgradeAbility
{
    public GameObject prefabField;
    public Upgrade[] upgrades;

    public float Radius => stats.FirstOrDefault(x => x.Type == StatType.Radius).GetValue(Level);

    public override void Action()
    {
        var field = GameManager.player.AddComponent<MagneticField>();
        field.Initialize(this);
        GlobalEventManager.Start_AddItem(this);
    }
}
