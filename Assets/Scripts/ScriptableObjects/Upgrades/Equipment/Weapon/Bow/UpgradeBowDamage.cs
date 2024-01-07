using UnityEngine;

[CreateAssetMenu(fileName = "BowDamage", menuName = "Upgrades/Weapons/Bow/Damage")]
public class UpgradeBowDamage : Upgrade
{
    public override void Action()
    {
        switch (level)
        {
            case 1:
                GameManager.player.GetComponent<Bow>().Damage += 2;
                break;
            case 2:
                GameManager.player.GetComponent<Bow>().Damage += 5;
                break;
            case 3:
                GameManager.player.GetComponent<Bow>().Damage += 7;
                break;
        }
    }
}
