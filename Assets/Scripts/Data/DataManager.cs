using System;
using System.IO;
using UnityEngine;
using System.Linq;
using UnityEditor;
using YG;

public class DataManager : MonoBehaviour
{
    public static DataManager instance = null;
    
    public GameData gameData => YandexGame.savesData;

    public UpgradeWeapon[] weapons;
    public UpgradeAbility[] abilities;
    public Hero[] heroes;
    public ImprovementStat[] improvements;

    private string filePath;

    private void Awake()
    {
        var objects = GameObject.FindGameObjectsWithTag("Data");
        if (objects.Length > 1) Destroy(gameObject);
        
        if (instance != null && instance != this)
            Destroy(this);
        else
            instance = this;

        GlobalEventManager.IncreaseCoinsData.AddListener(IncreaseCoins);
        GlobalEventManager.DecreaseCoinsData.AddListener(DecreaseCoins);
        filePath = Application.persistentDataPath + "GameData.json";
        
        DontDestroyOnLoad(gameObject);
    }

    private void CreateNew()
    {
        var textAssetJson = Resources.Load<TextAsset>("GameData/GameData");
        YandexGame.savesData = JsonUtility.FromJson<GameData>(textAssetJson.text);
        Save();
    }

    public void Save()
    {
        //string gameDataJson = JsonUtility.ToJson(gameData);
        //File.WriteAllText(filePath, gameDataJson);
        YandexGame.SaveProgress();
    }

    public void Load()
    {
        if (File.Exists(filePath))
        {
            string gameDataJson = File.ReadAllText(filePath);
            //gameData = JsonUtility.FromJson<GameData>(gameDataJson);
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