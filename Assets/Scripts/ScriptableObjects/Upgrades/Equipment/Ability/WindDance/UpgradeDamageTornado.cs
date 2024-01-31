using UnityEngine;

[CreateAssetMenu(fileName = "Damage", menuName = "Upgrades/Abilities/WindDance/Damage")]
public class UpgradeDamageTornado : UpgradeStats
{
    public float damage;

    public override void Action()
    {
        GameManager.player.GetComponent<WindDance>().damage += damage;
    }
}