using UnityEngine;

[CreateAssetMenu(fileName = "SwordAttackSpeed", menuName = "Upgrades/Weapons/Sword/AttackSpeed")]
public class UpgradeAttackSpeedSword : UpgradeStats
{
    public float scaleFrequency;

    public override void Action()
    {
        GameManager.player.GetComponent<Sword>().scaleFrequency -= scaleFrequency;
    }
}