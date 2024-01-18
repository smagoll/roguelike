using UnityEngine;

[CreateAssetMenu(fileName = "AddSword", menuName = "Upgrades/Add/Weapons/Sword")]
public class UpgradeAddSword : UpgradeWeapon
{
    public float damage;
    public GameObject prefabSword;
    public GameObject prefabSwordObject;
    public float attackRange;
    public float startFrequencyAttack;
    public Upgrade[] upgrades;

    public override void Action()
    {
        var sword = GameManager.player.AddComponent<Sword>();
        sword.Initialize(this);
    }
}
