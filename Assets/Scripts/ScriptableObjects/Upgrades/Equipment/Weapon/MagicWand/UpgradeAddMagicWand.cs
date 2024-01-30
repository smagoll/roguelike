using UnityEngine;

[CreateAssetMenu(fileName = "AddMagicWand", menuName = "Upgrades/Add/Weapons/MagicWand")]
public class UpgradeAddMagicWand : UpgradeWeapon
{
    [Header("Stats")]
    [SerializeField]
    private float damage;
    [SerializeField]
    private float frequency;

    public GameObject prefabSphere;
    public int countSphere;
    public float radiusSphere;
    public float attackRange;
    public float distanceFlight;
    public float speedFlight;
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
        var magicWand = GameManager.player.AddComponent<MagicWand>();
        magicWand.Initialize(prefabSphere, attackRange, radiusSphere, countSphere, speedFlight, distanceFlight, Damage, Frequency, upgrades) ;
    }
}
