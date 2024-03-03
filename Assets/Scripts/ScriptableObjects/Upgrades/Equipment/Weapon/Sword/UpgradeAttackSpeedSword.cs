using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "SwordAttackSpeed", menuName = "Upgrades/Weapons/Sword/AttackSpeed")]
public class UpgradeAttackSpeedSword : UpgradeStats
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
        GameManager.player.GetComponent<Sword>().scaleFrequency -= scaleFrequency;
    }
}