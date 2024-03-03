using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "Damage", menuName = "Upgrades/Abilities/ZipZap/Damage")]
public class UpgradeDamageZipZap : UpgradeStats
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
        GameManager.player.GetComponent<ZipZap>().damage += damage;
    }
}
