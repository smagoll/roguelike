using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveGameData
{
    public GameData gameData = new();
    private string filePath = Application.persistentDataPath + "/GameData.json";

    public SaveGameData(int countCoins, UpgradeAbility[] abilities, UpgradeWeapon[] weapons)
    {
        gameData.coins = countCoins;
        gameData.abilities = new();
        gameData.weapons = new();

        foreach (var ability in abilities)
        {
            var abilityData = new EquipmentData(ability.Id, ability.Level, ability.IsOpen);
            gameData.abilities.Add(abilityData);
        }
        
        foreach (var weapon in weapons)
        {
            var weaponData = new EquipmentData(weapon.Id, weapon.Level, weapon.IsOpen);
            gameData.weapons.Add(weaponData);
        }
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

    }
}
