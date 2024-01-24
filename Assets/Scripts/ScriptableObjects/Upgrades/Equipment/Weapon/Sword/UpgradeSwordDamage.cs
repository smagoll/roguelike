using UnityEngine;

[CreateAssetMenu(fileName = "SwordDamage", menuName = "Upgrades/Weapons/Sword/Damage")]
public class UpgradeSwordDamage : UpgradeStats
{
    public float damage;

    public override void Action()
    {
        GameManager.player.GetComponent<Sword>().Damage += damage;//3,5,7
    }
}
