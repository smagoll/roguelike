using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "BowDamage", menuName = "Upgrades/Weapons/Bow/Damage")]
public class UpgradeBowDamage : UpgradeStats
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
        GameManager.player.GetComponent<Bow>().Damage += damage;//2,5,7
    }
}
