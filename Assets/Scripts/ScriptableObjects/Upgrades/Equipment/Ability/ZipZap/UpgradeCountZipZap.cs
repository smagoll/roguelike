using UnityEngine;

[CreateAssetMenu(fileName = "Count", menuName = "Upgrades/Abilities/ZipZap/Count")]
public class UpgradeCountZipZap : UpgradeStats
{
    public int count;

    public override void Action()
    {
        GameManager.player.GetComponent<ZipZap>().countLightnings += count;
    }
}
