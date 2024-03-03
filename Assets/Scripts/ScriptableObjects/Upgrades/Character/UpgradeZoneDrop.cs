using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "UpgradeZoneDrop", menuName = "Upgrades/Character/ZoneDrop")]
public class UpgradeZoneDrop : UpgradeStats
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
        GameManager.player.GetComponent<Character>().dropCollector.ScaleRadius += scaleRadius;//10,20,30
    }
}
