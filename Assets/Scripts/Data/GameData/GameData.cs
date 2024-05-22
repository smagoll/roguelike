using UnityEngine;

[System.Serializable]
public class GameData
{
    // "Технические сохранения" для работы плагина (Не удалять)
    public int idSave;
    public bool isFirstSession = true;
    public string language = "ru";
    public bool promptDone;
    
    public int record = 0;
    public int coins = 0;
    public EquipmentData[] weapons;
    public EquipmentData[] abilities;
    public HeroData[] heroes;
    public ImprovementStatData[] improvements;
    public Prices prices;
    public EquipmentSelectedData equipmentSelected = new();
    public SettingsData settings = new();
}