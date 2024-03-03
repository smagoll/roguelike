using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "AttackSpeed", menuName = "Upgrades/Weapons/MagicWand/AttackSpeed")]
public class UpgradeAttackSpeedMagicWand : UpgradeStats
{
    public float scaleFrequency;

    public override LocalizedString Description
    {
        get
        {
            description.Arguments = new object[] { scaleFrequency };
            description.RefreshString();
            return description;
        }
    }

    public override void Action()
    {
        GameManager.player.GetComponent<MagicWand>().scaleFrequency -= scaleFrequency;
    }
}