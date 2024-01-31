using UnityEngine;

[CreateAssetMenu(fileName = "CountSphere", menuName = "Upgrades/Weapons/MagicWand/CountSphere")]
public class UpgradeCountSphere : UpgradeStats
{
    public int countSphere;

    public override void Action()
    {
        GameManager.player.GetComponent<MagicWand>().SpawnSphere(countSphere);
    }
}