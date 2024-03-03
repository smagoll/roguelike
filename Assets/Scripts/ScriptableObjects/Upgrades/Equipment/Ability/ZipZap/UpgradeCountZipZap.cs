using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "Count", menuName = "Upgrades/Abilities/ZipZap/Count")]
public class UpgradeCountZipZap : UpgradeStats
{
    public int count;

    public override LocalizedString Description
    {
        get
        {
            description.Arguments = new object[] { count };
            description.RefreshString();
            return description;
        }
    }

    public override void Action()
    {
        GameManager.player.GetComponent<ZipZap>().countLightnings += count;
    }
}
