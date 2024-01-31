using UnityEngine;

[CreateAssetMenu(fileName = "AttackSpeed", menuName = "Upgrades/Weapons/MagicWand/AttackSpeed")]
public class UpgradeAttackSpeedMagicWand : UpgradeStats
{
    public float scaleFrequency;

    public override void Action()
    {
        GameManager.player.GetComponent<MagicWand>().scaleFrequency -= scaleFrequency;
    }
}