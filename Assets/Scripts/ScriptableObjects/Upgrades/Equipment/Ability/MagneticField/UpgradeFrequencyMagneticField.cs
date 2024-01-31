using UnityEngine;

[CreateAssetMenu(fileName = "Frequency", menuName = "Upgrades/Abilities/MagneticField/Frequency")]
public class UpgradeFrequencyMagneticField : UpgradeStats
{
    public float scaleFrequency;

    public override void Action()
    {
        GameManager.player.GetComponent<MagneticField>().scaleFrequency -= scaleFrequency;
    }
}