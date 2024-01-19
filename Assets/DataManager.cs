using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Linq;

public class DataManager : MonoBehaviour
{
    public static GameData gameData = new();

    public int countCoins = 0;

    private string filePath;

    private void Awake()
    {
        GlobalEventManager.IncreaseCoins.AddListener(IncreaseCoins);
        GlobalEventManager.DecreaseCoins.AddListener(DecreaseCoins);
        filePath = Application.persistentDataPath + "/GameData.json";
        Load();
    }
    
    public void Save()
    {
        gameData.coins = countCoins;
        string gameDataJson = JsonUtility.ToJson(gameData);
        File.WriteAllText(filePath, gameDataJson);
    }

    public void Load()
    {
        if (File.Exists(filePath))
        {
            string gameDataJson = File.ReadAllText(filePath);
            gameData = JsonUtility.FromJson<GameData>(gameDataJson);
        }
        else
        {
            Save();
        }
    }

    private void IncreaseCoins(int coins)
    {
        countCoins += coins;

        Save();
    }
    
    private void DecreaseCoins(int coins)
    {
        countCoins -= coins;

        Save();
    }
}
