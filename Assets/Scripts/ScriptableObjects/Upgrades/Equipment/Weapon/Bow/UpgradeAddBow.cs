using UnityEngine;

[CreateAssetMenu(fileName = "AddBow", menuName = "Upgrades/Add/Weapons/Bow")]
public class UpgradeAddBow : UpgradeWeapon
{
    [Header("Stats")]
    [SerializeField]
    private float damage;
    [SerializeField]
    private float frequency;

    public GameObject prefabSword;
    public float attackRange;
    public float distanceFlight;
    public float speedFlightArrow;
    public Upgrade[] upgrades;
    [Header("Steps")]
    [SerializeField]
    private float stepDamage;
    [SerializeField]
    private float stepFrequency;

    public float Damage => damage + stepDamage * (Level - 1);
    public float Frequency => frequency - stepFrequency * (Level - 1);

    public override void Action()
    {
        var bow = GameManager.player.AddComponent<Bow>();
        bow.Initialize(this);
    }
}
