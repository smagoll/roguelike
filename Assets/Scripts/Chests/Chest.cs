using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public ChestData chest;
    public RareType rare;

    private void Awake()
    {
        chest = DataManager.instance.gameData.prices.chests.FirstOrDefault(x => x.rare == rare);
    }

    public void Action() { 
    }

    public void Buy()
    {
        if (DataManager.instance.countCoins >= chest.price)
        {
            DataManager.instance.countCoins -= chest.price;
            DataManager.instance.Save();
            Action();
        }
    }
}