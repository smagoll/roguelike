using UnityEngine;

[CreateAssetMenu(fileName = "FrequencyBow", menuName = "Upgrades/Weapons/Bow/Frequency")]
public class UpgradeFrequencyBow : UpgradeStats
{
    public float scaleFrequency;

    public override void Action()
    {
        GameManager.player.GetComponent<Bow>().scaleFrequency -= scaleFrequency;//1,3,5
    }
}
