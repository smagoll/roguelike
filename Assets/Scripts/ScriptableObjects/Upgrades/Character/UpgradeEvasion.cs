using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeEvasion", menuName = "Upgrades/Character/Evasion")]
public class UpgradeEvasion : UpgradeStats
{
    public float evasion;

    public override void Action()
    {
        GameManager.player.GetComponent<Character>().Evasion += evasion;//1,2,3
    }
}
