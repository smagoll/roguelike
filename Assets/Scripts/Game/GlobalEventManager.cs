using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GlobalEventManager : MonoBehaviour
{
    public static UnityEvent<List<Upgrade>> ShowUpgrades = new();
    public static UnityEvent<int, EquipmentType> ShowWindowUpgrade = new();
    public static UnityEvent<float> IncreaseHP = new();
    public static UnityEvent<float> UpdateXp = new();
    public static UnityEvent<int> OpenEnemies = new();
    public static UnityEvent<DropManager.DropType, Vector2> SpawnDrop = new();
    public static UnityEvent<float, float> UpdateHealthBar = new();
    public static UnityEvent<int, float, float> UpdateStageBar = new();
    public static UnityEvent<Vector3, float, TextHit> CreateDamageHurt = new();
    public static UnityEvent<UpgradeEquipment> AddItem = new();
    public static UnityEvent<Upgrade> AddUpgrade = new();
    public static UnityEvent<Upgrade> RemoveUpgrade = new();
    public static UnityEvent UpdateCoinMenu = new();
    public static UnityEvent<int> IncreaseCoinGame = new();
    public static UnityEvent<int> UpdateCoinGameText = new();
    public static UnityEvent<int> IncreaseCoinsData = new();
    public static UnityEvent<int> DecreaseCoinsData = new();
    public static UnityEvent EndGame = new();
    public static UnityEvent PauseGame = new();

    public static void Start_ShowUpgrades(List<Upgrade> upgrades)
    {
        ShowUpgrades.Invoke(upgrades);
    }
        
    public static void Start_UpdateXp(float xp)
    {
        UpdateXp.Invoke(xp);
    }
    
    public static void Start_OpenEnemies(int stage)
    {
        OpenEnemies.Invoke(stage);
    }
    
    public static void Start_UpdateHealthBar(float health, float maxHealth)
    {
        UpdateHealthBar.Invoke(health, maxHealth);
    }
    
    public static void Start_UpdateStageBar(int stage, float xpCollect, float xpForCurrentStage)
    {
        UpdateStageBar.Invoke(stage, xpCollect, xpForCurrentStage);
    }
    
    public static void Start_CreateDamageHurt(Vector3 position, float damage, TextHit textHit)
    {
        CreateDamageHurt.Invoke(position, damage, textHit);
    } 
    
    public static void Start_IncreaseHP(float hp)
    {
        IncreaseHP.Invoke(hp);
    }
    
    public static void Start_AddItem(UpgradeEquipment upgrade)
    {
        AddItem.Invoke(upgrade);
    }
    
    public static void Start_UpdateCoinMenu()
    {
        UpdateCoinMenu.Invoke();
    }

    public static void Start_IncreaseCoins(int coins)
    {
        IncreaseCoinsData.Invoke(coins);
    }
    
    public static void Start_DecreaseCoins(int coins)
    {
        DecreaseCoinsData.Invoke(coins);
    }
    
    public static void Start_IncreaseCoinGame(int coins)
    {
        IncreaseCoinGame.Invoke(coins);
    }
    
    public static void Start_UpdateCoinGameText(int coins)
    {
        UpdateCoinGameText.Invoke(coins);
    }
    
    public static void Start_EndGame()
    {
        EndGame.Invoke();
    }
    
    public static void Start_PauseGame()
    {
        PauseGame.Invoke();
    }
    
    public static void Start_ShowWindowUpgrade(int id, EquipmentType equipmentType)
    {
        ShowWindowUpgrade.Invoke(id, equipmentType);
    }
    
    public static void Start_AddUpgrade(Upgrade upgrade)
    {
        AddUpgrade.Invoke(upgrade);
    }

    public static void Start_RemoveUpgrade(Upgrade upgrade)
    {
        RemoveUpgrade.Invoke(upgrade);
    }
    
    public static void Start_SpawnDrop(DropManager.DropType dropType, Vector2 position)
    {
        SpawnDrop.Invoke(dropType, position);
    }
}
