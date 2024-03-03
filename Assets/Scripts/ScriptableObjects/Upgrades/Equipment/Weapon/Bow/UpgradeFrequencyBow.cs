using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "FrequencyBow", menuName = "Upgrades/Weapons/Bow/Frequency")]
public class UpgradeFrequencyBow : UpgradeStats
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
        GameManager.player.GetComponent<Bow>().scaleFrequency -= scaleFrequency;//1,3,5
    }
}
