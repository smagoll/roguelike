using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "CountSphere", menuName = "Upgrades/Weapons/MagicWand/CountSphere")]
public class UpgradeCountSphere : UpgradeStats
{
    public int countSphere;

    public override LocalizedString Description
    {
        get
        {
            description.Arguments = new object[] { countSphere };
            description.RefreshString();
            return description;
        }
    }

    public override void Action()
    {
        GameManager.player.GetComponent<MagicWand>().SpawnSphere(countSphere);
    }
}