using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeZoneDrop", menuName = "Upgrades/Character/ZoneDrop")]
public class UpgradeZoneDrop : UpgradeStats
{
    public float scaleRadius;

    public override void Action()
    {
        GameManager.player.GetComponent<Character>().dropCollector.ScaleRadius += scaleRadius;//10,20,30
    }
}
