using UnityEngine;

[CreateAssetMenu(fileName = "SwordRadius", menuName = "Upgrades/Weapons/Sword/Radius")]
public class UpgradeRangeAttackSword : UpgradeStats
{
    public float scaleRadius;

    public override void Action()
    {
        GameManager.player.GetComponent<Sword>().ScaleAttackRange += scaleRadius;
    }
}
