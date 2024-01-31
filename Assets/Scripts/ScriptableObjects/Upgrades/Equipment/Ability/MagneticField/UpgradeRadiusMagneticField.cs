using UnityEngine;

[CreateAssetMenu(fileName = "Radius", menuName = "Upgrades/Abilities/MagneticField/Radius")]
public class UpgradeRadiusMagneticField : UpgradeStats
{
    public float scaleRadius;

    public override void Action()
    {
        GameManager.player.GetComponent<MagneticField>().ScaleRadius += scaleRadius;
    }
}