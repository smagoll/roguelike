using System.Linq;
using UnityEngine;

public abstract class UpgradeEquipment : Upgrade
{
    [Header("General")]
    [SerializeField]
    private int id;

    public EquipmentType equipmentType;
    public override UpgradeType UpgradeType => UpgradeType.Add;

    public Stat[] stats;

    public int Id { get => id; set => id = value; }
    public int Level
    {
        get
        {
            switch (equipmentType)
            {
                case EquipmentType.Weapon:
                    return DataManager.instance.gameData.heroes.Where(x => x.id == DataManager.instance.gameData.equipmentSelected.id_hero).FirstOrDefault().level;
                case EquipmentType.Ability:
                    return DataManager.instance.gameData.abilities.Where(x => x.id == id).FirstOrDefault().level;
            }
            return 1;
        }
    }
}