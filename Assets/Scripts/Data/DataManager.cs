using System;
using System.IO;
using UnityEngine;
using System.Linq;
using UnityEditor;

public class DataManager : MonoBehaviour
{
    public static DataManager instance = null;

    public GameData gameData = new();

    public UpgradeWeapon[] weapons;
    public UpgradeAbility[] abilities;
    public Hero[] heroes;
    public ImprovementStat[] improvements;

    private string filePath;

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this);
        else
            instance = this;

        GlobalEventManager.IncreaseCoinsData.AddListener(IncreaseCoins);
        GlobalEventManager.DecreaseCoinsData.AddListener(DecreaseCoins);
        filePath = Application.persistentDataPath + "GameData.json";
        Load();
    }

    private void CreateNew()
    {
        var textAssetJson = Resources.Load<TextAsset>("GameData/GameData");
        gameData = JsonUtility.FromJson<GameData>(textAssetJson.text);
        Save();
    }

    public void Save()
    {
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
            CreateNew();
        }
    }

    private void IncreaseCoins(int coins)
    {
        gameData.coins += coins;

        Save();
    }
    
    private void DecreaseCoins(int coins)
    {
        gameData.coins -= coins;

        Save();
    }

    public Hero GetEquipmentHero()
    {
        return heroes.Where(x => x.Id == gameData.equipmentSelected.id_hero).FirstOrDefault();
    }
}