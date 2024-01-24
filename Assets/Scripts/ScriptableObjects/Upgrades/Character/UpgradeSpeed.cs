using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeSpeed", menuName = "Upgrades/Character/Speed")]
public class UpgradeSpeed : UpgradeStats
{
    public float scaleSpeed;

    public override void Action()
    {
        GameManager.player.GetComponent<Character>().ScaleSpeed += scaleSpeed;//10,20,30
    }
}
