using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    public Upgrade[] upgrades;

    private void Start()
    {
        if (upgrades.Length > 0)
        {
            foreach (var upgrade in upgrades)
            {
                GameManager.AddUpgrade(upgrade);
            }
        }
    }
}
