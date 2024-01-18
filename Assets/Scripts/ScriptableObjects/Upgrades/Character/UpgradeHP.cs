using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeHP", menuName = "Upgrades/Character/HP")]
public class UpgradeHP : Upgrade
{
    public override void Action()
    {
        switch (rare)
        {
            case 1:
                GameManager.player.GetComponent<Character>().ScaleHp += 10;
                break;
            case 2:
                GameManager.player.GetComponent<Character>().ScaleHp += 15;
                break;
            case 3:
                GameManager.player.GetComponent<Character>().ScaleHp += 25;
                break;
        }
    }
}
