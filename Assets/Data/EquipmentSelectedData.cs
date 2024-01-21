using System.Collections.Generic;

[System.Serializable]
public class EquipmentSelectedData
{
    public int id_hero;
    public List<int> id_weapons = new();
    public List<int> id_abilities = new();
}
