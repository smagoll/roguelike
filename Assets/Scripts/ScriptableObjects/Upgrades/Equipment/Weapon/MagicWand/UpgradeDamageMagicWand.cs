using UnityEngine;

[CreateAssetMenu(fileName = "Damage", menuName = "Upgrades/Weapons/MagicWand/Damage")]
public class UpgradeDamageMagicWand : UpgradeStats
{
    public float damage;

    public override void Action()
    {
        GameManager.player.GetComponent<MagicWand>().Damage += damage;
    }
}