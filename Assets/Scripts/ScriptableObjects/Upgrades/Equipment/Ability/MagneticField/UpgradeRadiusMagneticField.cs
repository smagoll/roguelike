using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "Radius", menuName = "Upgrades/Abilities/MagneticField/Radius")]
public class UpgradeRadiusMagneticField : UpgradeStats
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
        GameManager.player.GetComponent<MagneticField>().ScaleRadius += scaleRadius;
    }
}