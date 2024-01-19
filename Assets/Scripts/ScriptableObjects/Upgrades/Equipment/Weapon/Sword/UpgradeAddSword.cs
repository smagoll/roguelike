using UnityEngine;

[CreateAssetMenu(fileName = "AddSword", menuName = "Upgrades/Add/Weapons/Sword")]
public class UpgradeAddSword : UpgradeWeapon
{
    [Header("Stats")]
    [SerializeField]
    private float damage;
    [SerializeField]
    private float frequency;

    public GameObject prefabSword;
    public GameObject prefabSwordObject;
    public float attackRange;
    public float startFrequencyAttack;
    public Upgrade[] upgrades;

    [Header("Steps")]
    public float stepDamage;
    public float stepFrequency;

    public float Damage => damage + stepDamage * (Level - 1);
    public float Frequency => frequency - stepFrequency * (Level - 1);

    public override void Action()
    {
        var sword = GameManager.player.AddComponent<Sword>();
        sword.Initialize(this);
    }
}
