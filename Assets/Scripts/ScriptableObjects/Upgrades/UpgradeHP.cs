using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeHP", menuName = "Upgrades/UpgradesCharacter/UpgradeHP")]
public class UpgradeHP : Upgrade
{
    public int level;

    public override void Action()
    {
        switch (level)
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
