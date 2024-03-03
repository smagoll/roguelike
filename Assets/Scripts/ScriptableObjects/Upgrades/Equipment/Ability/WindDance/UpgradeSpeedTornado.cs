using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "Speed", menuName = "Upgrades/Abilities/WindDance/Speed")]
public class UpgradeSpeedTornado : UpgradeStats
{
    public float scaleSpeed;

    public override LocalizedString Description
    {
        get
        {
            description.Arguments = new object[] { scaleSpeed };
            description.RefreshString();
            return description;
        }
    }

    public override void Action()
    {
        GameManager.player.GetComponent<WindDance>().scaleSpeedFlight += scaleSpeed;
    }
}