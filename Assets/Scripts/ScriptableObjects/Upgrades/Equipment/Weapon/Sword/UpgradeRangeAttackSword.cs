using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "SwordRadius", menuName = "Upgrades/Weapons/Sword/Radius")]
public class UpgradeRangeAttackSword : UpgradeStats
{
    public float scaleRadius;

    public override LocalizedString Description
    {
        get
        {
            description.Arguments = new object[] { scaleRadius };
            description.RefreshString();
            return description;
        }
    }

    public override void Action()
    {
        GameManager.player.GetComponent<Sword>().ScaleAttackRange += scaleRadius;
    }
}
