using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static SaveGameData gameData;
    public int countCoins;
    public UpgradeAbility[] abilities;
    public UpgradeWeapon[] weapons;

    private void Start()
    {
        gameData = new(countCoins, abilities, weapons);
    }
}
