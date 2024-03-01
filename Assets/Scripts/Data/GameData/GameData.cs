[System.Serializable]
public class GameData
{
    public int record;
    public int coins;
    public EquipmentData[] weapons;
    public EquipmentData[] abilities;
    public HeroData[] heroes;
    public ImprovementStatData[] improvements;
    public Prices prices;
    public EquipmentSelectedData equipmentSelected = new();
    public SettingsData settings = new();
}