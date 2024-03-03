using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "CountTornado", menuName = "Upgrades/Abilities/WindDance/CountTornado")]
public class UpgradeCountTornado : UpgradeStats
{
    public int countTornado;

    public override LocalizedString Description
    {
        get
        {
            description.Arguments = new object[] { countTornado };
            description.RefreshString();
            return description;
        }
    }

    public override void Action()
    {
        GameManager.player.GetComponent<WindDance>().CountTornado += countTornado;
    }
}