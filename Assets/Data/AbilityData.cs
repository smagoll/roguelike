[System.Serializable]
public struct AbilityData : IEquipmentData
{
    public int iid;
    public int Id { get; set; }
    public int Level { get; set; }
    public bool IsOpen { get; set; }

    public AbilityData(int id, int level, bool isOpen) : this()
    {
        Id = id;
        Level = level;
        IsOpen = isOpen;
    }
}
