using UnityEngine;

[CreateAssetMenu(fileName = "ArrowThrough", menuName = "Upgrades/Weapons/Bow/ArrowThrough")]
public class UpgradeArrow : Upgrade
{
    public override UpgradeType UpgradeType => UpgradeType.Add;

    public override void Action()
    {
        GameManager.player.GetComponent<Bow>().isArrowThrough = true;
    }
}
