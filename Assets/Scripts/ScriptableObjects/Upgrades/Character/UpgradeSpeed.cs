using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeSpeed", menuName = "Upgrades/Character/Speed")]
public class UpgradeSpeed : Upgrade
{

    public override void Action()
    {
        switch (rare)
        {
            case 1:
                GameManager.player.GetComponent<Character>().ScaleSpeed += 10;
                break;
            case 2:
                GameManager.player.GetComponent<Character>().ScaleSpeed += 20;
                break;
            case 3:
                GameManager.player.GetComponent<Character>().ScaleSpeed += 30;
                break;
        }
    }
}
