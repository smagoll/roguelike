using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "UpgradeSpeed", menuName = "Upgrades/Character/Speed")]
public class UpgradeSpeed : UpgradeStats
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
        GameManager.player.GetComponent<Character>().ScaleSpeed += scaleSpeed;//10,20,30
    }
}
