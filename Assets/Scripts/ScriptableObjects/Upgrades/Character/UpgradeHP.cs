using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeHP", menuName = "Upgrades/Character/HP")]
public class UpgradeHP : UpgradeStats
{
    public float hp;

    public override void Action()
    {
        GameManager.player.GetComponent<Character>().ScaleHp += hp;//10,15,25
    }
}
