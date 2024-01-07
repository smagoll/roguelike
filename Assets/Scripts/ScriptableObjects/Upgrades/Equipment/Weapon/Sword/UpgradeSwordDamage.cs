using UnityEngine;

[CreateAssetMenu(fileName = "SwordDamage", menuName = "Upgrades/Weapons/Sword/Damage")]
public class UpgradeSwordDamage : Upgrade
{
    public override void Action()
    {
        switch (level)
        {
            case 1:
                GameManager.player.GetComponent<Sword>().Damage += 3;
                break;
            case 2:
                GameManager.player.GetComponent<Sword>().Damage += 5;
                break;
            case 3:
                GameManager.player.GetComponent<Sword>().Damage += 7;
                break;
        }
    }
}
