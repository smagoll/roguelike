using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct GameData
{
    public int coins;
    public EquipmentData[] weapons;
    public EquipmentData[] abilities;

    public GameData(int coins, EquipmentData[] weapons, EquipmentData[] abilities)
    {
        this.coins = coins;
        this.weapons = weapons;
        this.abilities = abilities;
    }
}