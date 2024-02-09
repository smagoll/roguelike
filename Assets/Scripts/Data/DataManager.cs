using System.Collections;
using System.Collections.Generic;
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

    public int countCoins = 0;

    private string filePath;

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this);
        else
            instance = this;

        GlobalEventManager.IncreaseCoinsData.AddListener(IncreaseCoins);
        GlobalEventManager.DecreaseCoinsData.AddListener(DecreaseCoins);
        filePath = Application.dataPath + "/Data/Json/GameData.json";
        Load();
    }
    
    public void Save()
    {
        //string gameDataJson = JsonUtility.ToJson(gameData);
        //File.WriteAllText(filePath, gameDataJson);
    }

    public void Load()
    {
        if (File.Exists(filePath))
        {
            string gameDataJson = File.ReadAllText(filePath);
            gameData = JsonUtility.FromJson<GameData>(gameDataJson);
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