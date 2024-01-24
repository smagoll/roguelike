using UnityEngine;

[CreateAssetMenu(fileName = "BowDamage", menuName = "Upgrades/Weapons/Bow/Damage")]
public class UpgradeBowDamage : UpgradeStats
{
    public float damage;

    public override void Action()
    {
        GameManager.player.GetComponent<Bow>().Damage += damage;//2,5,7
    }
}
