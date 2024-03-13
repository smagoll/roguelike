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

    public override void Action()
    {
        var magicWand = GameManager.player.AddComponent<MagicWand>();
        magicWand.Initialize(prefabSphere, attackRange, radiusSphere, countSphere, speedFlight, distanceFlight, Damage, Frequency, upgrades) ;
        foreach (var upgrade in upgrades) upgrade.objectUpgrade = this;
        GlobalEventManager.Start_AddItem(this);
    }
}
