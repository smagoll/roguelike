using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Linq;

public class DataManager : MonoBehaviour
{
    public static GameData gameData = new();

    [SerializeField]
    private UpgradeWeapon[] weapons;
    [SerializeField]
    private UpgradeAbility[] abilities;
    [SerializeField]
    private Hero[] heroes;

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

        gameData.heroes = heroes.Select(x => new HeroData(x.Id, false)).OrderBy(x => x.id).ToArray();
        gameData.heroes[0].isOpen = true;

        gameData.equipmentSelected.id_hero = 1;
        gameData.equipmentSelected.id_weapons.Add(1);

        Save();
    }
}
