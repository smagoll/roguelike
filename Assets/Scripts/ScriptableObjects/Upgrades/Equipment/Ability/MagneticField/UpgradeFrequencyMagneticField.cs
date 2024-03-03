using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "Frequency", menuName = "Upgrades/Abilities/MagneticField/Frequency")]
public class UpgradeFrequencyMagneticField : UpgradeStats
{
    public float scaleFrequency;

    public override LocalizedString Description
    {
        get
        {
            description.Arguments = new object[] { scaleFrequency };
            description.RefreshString();
            return description;
        }
    }

    public override void Action()
    {
        GameManager.player.GetComponent<MagneticField>().scaleFrequency -= scaleFrequency;
    }
}