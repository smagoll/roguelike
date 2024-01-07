using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GlobalEventManager : MonoBehaviour
{
    public static UnityEvent<List<Upgrade>> ShowUpgrades = new();
    public static UnityEvent<float> IncreaseHP = new();
    public static UnityEvent<float> UpdateXp = new();
    public static UnityEvent<int> OpenEnemies = new();
    public static UnityEvent<float, float> UpdateHealthBar = new();
    public static UnityEvent<int, float, float> UpdateStageBar = new();
    public static UnityEvent<Vector3, float, TextHit> CreateDamageHurt = new();
    public static UnityEvent<Upgrade> AddItem = new();

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
    
    public static void Start_AddItem(Upgrade upgrade)
    {
        AddItem.Invoke(upgrade);
    }
}
