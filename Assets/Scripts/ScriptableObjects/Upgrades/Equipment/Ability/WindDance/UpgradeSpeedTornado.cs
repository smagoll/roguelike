using UnityEngine;

[CreateAssetMenu(fileName = "Speed", menuName = "Upgrades/Abilities/WindDance/Speed")]
public class UpgradeSpeedTornado : UpgradeStats
{
    public float scaleSpeed;

    public override void Action()
    {
        GameManager.player.GetComponent<WindDance>().scaleSpeedFlight += scaleSpeed;
    }
}