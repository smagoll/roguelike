using UnityEngine;

public class Testing : MonoBehaviour
{
    public Upgrade[] upgrades;

    private void Start()
    {
        TestUpgrades(upgrades);
    }

    public void TestUpgrades(Upgrade[] upgrades)
    {
        foreach (var upgrade in upgrades)
            upgrade.Action();
    }

}
