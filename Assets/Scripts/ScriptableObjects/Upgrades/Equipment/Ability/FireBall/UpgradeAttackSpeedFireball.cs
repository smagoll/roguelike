using UnityEngine;

[CreateAssetMenu(fileName = "AttackSpeed", menuName = "Upgrades/Abilities/Fireball/AttackSpeed")]
public class UpgradeAttackSpeedFireball : UpgradeStats
{
    public float scaleAttackSpeed;

    public override void Action()
    {
        GameManager.player.GetComponent<FireBall>().scaleFrequency -= scaleAttackSpeed;
    }
}