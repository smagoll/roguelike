[System.Serializable]
public class EquipmentData
{
    public int id;
    public int level;
    public bool isOpen;

    public EquipmentData(int id, int level, bool isOpen)
    {
        this.id = id;
        this.level = level;
        this.isOpen = isOpen;
    }
}