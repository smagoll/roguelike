[System.Serializable]
public class EquipmentData
{
    public int id;
    public int level;

    public bool IsOpen => level > 0;

    public EquipmentData(int id, int level)
    {
        this.id = id;
        this.level = level;
    }
}