using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "Damage", menuName = "Upgrades/Abilities/Fireball/Damage")]
public class UpgradeDamageFireball : UpgradeStats
{
    public float damage;

    public override LocalizedString Description
    {
        get
        {
            description.Arguments = new object[] { damage };
            description.RefreshString();
            return description;
        }
    }

    public override void Action()
    {
        GameManager.player.GetComponent<FireBall>().damage += damage;
    }
}