using UnityEngine;

[CreateAssetMenu(fileName = "AttackSpeed", menuName = "Upgrades/Abilities/ZipZap/AttackSpeed")]
public class UpgradeAttackSpeedZipZap : UpgradeStats
{
    public float scaleAttackSpeed;

    public override void Action()
    {
        GameManager.player.GetComponent<ZipZap>().scaleFrequency -= scaleAttackSpeed;
    }
}