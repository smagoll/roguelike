using UnityEngine;

[CreateAssetMenu(fileName = "Damage", menuName = "Upgrades/Abilities/ZipZap/Damage")]
public class UpgradeDamageZipZap : UpgradeStats
{
    public float damage;

    public override void Action()
    {
        GameManager.player.GetComponent<ZipZap>().damage += damage;
    }
}
