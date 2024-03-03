using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "UpgradeEvasion", menuName = "Upgrades/Character/Evasion")]
public class UpgradeEvasion : UpgradeStats
{
    public float evasion;

    public override LocalizedString Description
    {
        get
        {
            description.Arguments = new object[] { evasion };
            description.RefreshString();
            return description;
        }
    }

    public override void Action()
    {
        GameManager.player.GetComponent<Character>().Evasion += evasion;//1,2,3
    }
}
