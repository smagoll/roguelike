using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeZoneDrop", menuName = "Upgrades/Character/ZoneDrop")]
public class UpgradeZoneDrop : Upgrade
{
    public override void Action()
    {
        switch (rare)
        {
            case 1:
                GameManager.player.GetComponent<Character>().dropCollector.ScaleRadius += 10;
                break;
            case 2:
                GameManager.player.GetComponent<Character>().dropCollector.ScaleRadius += 20;
                break;
            case 3:
                GameManager.player.GetComponent<Character>().dropCollector.ScaleRadius += 30;
                break;
        }
    }
}
