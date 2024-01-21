using System.Linq;
using UnityEngine;

public abstract class UpgradeEquipment : Upgrade, IEquipmentData
{
    [Header("General")]
    [SerializeField]
    private int id;

    public EquipmentType equipmentType;

    public int Id { get => id; set => id = value; }
    public int Level
    {
        get
        {
            switch (equipmentType)
            {
                case EquipmentType.Weapon:
                    return DataManager.gameData.weapons.Where(x => x.id == id).FirstOrDefault().level;
                case EquipmentType.Ability:
                    return DataManager.gameData.abilities.Where(x => x.id == id).FirstOrDefault().level;
            }
            return 1;
        }
    }
    public bool IsOpen
    {
        get
        {
            switch (equipmentType)
            {
                case EquipmentType.Weapon:
                    return DataManager.gameData.weapons.Where(x => x.id == id).FirstOrDefault().isOpen;
                case EquipmentType.Ability:
                    return DataManager.gameData.abilities.Where(x => x.id == id).FirstOrDefault().isOpen;
            }
            return false;
        }
    }
}