using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "Damage", menuName = "Upgrades/Abilities/WindDance/Damage")]
public class UpgradeDamageTornado : UpgradeStats
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
        GameManager.player.GetComponent<WindDance>().damage += damage;
    }
}