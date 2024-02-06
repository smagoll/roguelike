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
    public UpgradeEquipment[] abilities;
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
        else
        {
            CreateFirstSave();
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

    public void CreateFirstSave()
    {
        gameData.coins = 0;
        gameData.weapons = weapons.Select(x => new EquipmentData(x.Id, 1, false)).OrderBy(x => x.id).ToArray();
        gameData.abilities = abilities.Select(x => new EquipmentData(x.Id, 1, false)).OrderBy(x => x.id).ToArray();
        gameData.improvements = improvements.Select(x => new ImprovementStatData(x.id, x.Level)).OrderBy(x => x.id).ToArray();

        gameData.heroes = heroes.Select(x => new HeroData(x.Id, 1, false)).OrderBy(x => x.id).ToArray();
        gameData.heroes[0].isOpen = true;

        gameData.equipmentSelected.id_hero = 1;

        Save();
    }

    public Hero GetEquipmentHero()
    {
        return heroes.Where(x => x.Id == gameData.equipmentSelected.id_hero).FirstOrDefault();
    }
}