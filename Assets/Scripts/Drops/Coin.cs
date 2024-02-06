using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Drop
{
    public int countCoin;
    public override void Action()
    {
        GlobalEventManager.Start_IncreaseCoinGame(countCoin);
        Debug.Log(countCoin);
    }
}
