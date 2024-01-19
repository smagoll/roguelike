using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Linq;

public class DataManager : MonoBehaviour
{
    public GameData gameData = new();

    public int countCoins;
    public UpgradeAbility[] abilities;
    public UpgradeWeapon[] weapons;

    private string filePath;

    private void Awake()
    {
        filePath = Application.persistentDataPath + "/GameData.json";
        Load();
    }

    public void Save()
    {
        gameData.coins = countCoins;
        gameData.abilities = abilities.Select(x => new EquipmentData(x.Id, x.Level, x.IsOpen)).ToArray();
        gameData.weapons = weapons.Select(x => new EquipmentData(x.Id, x.Level, x.IsOpen)).ToArray();
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
    }
}
