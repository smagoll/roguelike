using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CountTornado", menuName = "Upgrades/Abilities/WindDance/CountTornado")]
public class UpgradeCountTornado : Upgrade
{
    public override void Action()
    {
        switch (level)
        {
            case 1:
                GameManager.player.GetComponent<WindDance>().CountTornado += 1;
                break;
            case 2:
                GameManager.player.GetComponent<WindDance>().CountTornado += 2;
                break;
            case 3:
                GameManager.player.GetComponent<WindDance>().CountTornado += 3;
                break;
        }
    }
}
