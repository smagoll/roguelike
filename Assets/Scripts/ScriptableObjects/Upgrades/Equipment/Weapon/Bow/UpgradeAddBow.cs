using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "AddBow", menuName = "Upgrades/Add/Weapons/Bow")]
public class UpgradeAddBow : UpgradeWeapon
{
    [Header("Stats")]
    public GameObject prefabSword;
    public float attackRange;
    public float distanceFlight;
    public float speedFlightArrow;
    public Upgrade[] upgrades;

    public override void Action()
    {
        var bow = GameManager.player.AddComponent<Bow>();
        bow.Initialize(this);
    }

}