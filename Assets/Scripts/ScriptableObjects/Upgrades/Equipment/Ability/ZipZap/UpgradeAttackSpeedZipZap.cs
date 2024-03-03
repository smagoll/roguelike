using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "AttackSpeed", menuName = "Upgrades/Abilities/ZipZap/AttackSpeed")]
public class UpgradeAttackSpeedZipZap : UpgradeStats
{
    public float scaleAttackSpeed;

    public override LocalizedString Description
    {
        get
        {
            description.Arguments = new object[] { scaleAttackSpeed };
            description.RefreshString();
            return description;
        }
    }

    public override void Action()
    {
        GameManager.player.GetComponent<ZipZap>().scaleFrequency -= scaleAttackSpeed;
    }
}