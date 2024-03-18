using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "AddBow", menuName = "Upgrades/Add/Weapons/Bow")]
public class UpgradeAddBow : UpgradeWeapon
{
    [Header("Stats")]
    public Arrow prefabArrow;
    public float attackRange;
    public float distanceFlight;
    public float speedFlightArrow;
    public Upgrade[] upgrades;

    public override void Action()
    {
        var bow = GameManager.player.AddComponent<Bow>();
        bow.Initialize(this);
        foreach (var upgrade in upgrades) upgrade.objectUpgrade = this;
        GlobalEventManager.Start_AddItem(this);
    }

}