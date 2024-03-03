using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "SwordDamage", menuName = "Upgrades/Weapons/Sword/Damage")]
public class UpgradeSwordDamage : UpgradeStats
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
        GameManager.player.GetComponent<Sword>().Damage += damage;//3,5,7
    }
}
