using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "Damage", menuName = "Upgrades/Weapons/MagicWand/Damage")]
public class UpgradeDamageMagicWand : UpgradeStats
{
    public float damage;

    public override LocalizedString Description
    {
        get
        {
            description.Arguments = new object[] { damage };
            description.RefreshString();
            return description;
        }
    }

    public override void Action()
    {
        GameManager.player.GetComponent<MagicWand>().Damage += damage;
    }
}