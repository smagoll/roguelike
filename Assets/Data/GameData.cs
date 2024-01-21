[System.Serializable]
public class GameData
{
    public int coins;
    public EquipmentData[] weapons;
    public EquipmentData[] abilities;
    public HeroData[] heroes;
    public EquipmentSelectedData equipmentSelected = new();
}