using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeSword", menuName = "Upgrades/UpgradesWeapon/UpgradeSwordDamage")]
public class UpgradeSwordDamage : Upgrade
{
    public int level;

    public override void Action()
    {
        switch (level)
        {
            case 1:
                GameManager.player.GetComponent<Sword>().damage += 3;
                break;
            case 2:
                GameManager.player.GetComponent<Sword>().damage += 5;
                break;
            case 3:
                GameManager.player.GetComponent<Sword>().damage += 7;
                break;
        }
    }
}
