using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "UpgradeHP", menuName = "Upgrades/Character/HP")]
public class UpgradeHP : UpgradeStats
{
    public float hp;

    public override LocalizedString Description
    {
        get
        {
            description.Arguments = new object[] { hp };
            description.RefreshString();
            return description;
        }
    }

    public override void Action()
    {
        GameManager.player.GetComponent<Character>().ScaleHp += hp;//10,15,25
    }
}
