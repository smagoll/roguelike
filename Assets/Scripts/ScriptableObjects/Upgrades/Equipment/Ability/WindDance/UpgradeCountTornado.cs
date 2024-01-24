using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CountTornado", menuName = "Upgrades/Abilities/WindDance/CountTornado")]
public class UpgradeCountTornado : UpgradeStats
{
    public int countTornado;

    public override void Action()
    {
        GameManager.player.GetComponent<WindDance>().CountTornado += countTornado;
    }
}
