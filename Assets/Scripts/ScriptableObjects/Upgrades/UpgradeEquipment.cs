using System.Linq;
using UnityEngine;

public abstract class UpgradeEquipment : Upgrade
{
    [Header("General")]
    [SerializeField]
    private int id;

    public EquipmentType equipmentType;
    public override UpgradeType UpgradeType => UpgradeType.Add;

    [Header("Stats")]
    public Stat[] stats;

    public float Damage => stats.FirstOrDefault(x => x.Type == StatType.Damage).GetValue(Level);
    public float Frequency => stats.FirstOrDefault(x => x.Type == StatType.Frequency).GetValue(Level);


    public int Id { get => id; set => id = value; }
    public int Level
    {
        get
        {
            switch (equipmentType)
            {
                case EquipmentType.Weapon:
                    return DataManager.instance.gameData.weapons.Where(x => x.id == id).FirstOrDefault().level;
                case EquipmentType.Ability:
                    return DataManager.instance.gameData.abilities.Where(x => x.id == id).FirstOrDefault().level;
            }
            return 1;
        }
    }

    public void LevelUp()
    {
        switch (equipmentType)
        {
            case EquipmentType.Weapon:
                DataManager.instance.gameData.weapons.FirstOrDefault(x => x.id == Id).level++;
                break;
            case EquipmentType.Ability:
                DataManager.instance.gameData.abilities.FirstOrDefault(x => x.id == Id).level++;
                break;
        }
    }
}