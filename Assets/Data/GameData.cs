using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct GameData
{
    public int coins;

    public GameData(int coins)
    {
        this.coins = coins;
    }
}