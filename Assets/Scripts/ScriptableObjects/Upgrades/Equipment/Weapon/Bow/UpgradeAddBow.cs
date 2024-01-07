using UnityEngine;

[CreateAssetMenu(fileName = "AddBow", menuName = "Upgrades/Add/Weapons/Bow")]
public class UpgradeAddBow : Upgrade
{
    public float damage;
    public GameObject prefabSword;
    public float attackRange;
    public float distanceFlight;
    public float frequency;
    public float speedFlightArrow;
    public Upgrade[] upgrades;

    public override void Action()
    {
        var bow = GameManager.player.AddComponent<Bow>();
        bow.Initialize(this);
    }
}
