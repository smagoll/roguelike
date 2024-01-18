using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeEvasion", menuName = "Upgrades/Character/Evasion")]
public class UpgradeEvasion : Upgrade
{
    public override void Action()
    {
        switch (rare)
        {
            case 1:
                GameManager.player.GetComponent<Character>().Evasion += 1;
                break;
            case 2:
                GameManager.player.GetComponent<Character>().Evasion += 2;
                break;
            case 3:
                GameManager.player.GetComponent<Character>().Evasion += 3;
                break;
        }
    }
}
