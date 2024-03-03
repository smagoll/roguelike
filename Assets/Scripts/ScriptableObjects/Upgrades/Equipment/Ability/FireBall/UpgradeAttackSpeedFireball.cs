using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "AttackSpeed", menuName = "Upgrades/Abilities/Fireball/AttackSpeed")]
public class UpgradeAttackSpeedFireball : UpgradeStats
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
        GameManager.player.GetComponent<FireBall>().scaleFrequency -= scaleAttackSpeed;
    }
}