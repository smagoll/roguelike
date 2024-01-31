using UnityEngine;

[CreateAssetMenu(fileName = "Damage", menuName = "Upgrades/Abilities/MagneticField/Damage")]
public class UpgradeDamageMagneticField : UpgradeStats
{
    public float damage;

    public override void Action()
    {
        GameManager.player.GetComponent<MagneticField>().damage += damage;
    }
}