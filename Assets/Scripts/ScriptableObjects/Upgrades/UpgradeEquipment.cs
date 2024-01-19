using UnityEngine;

public abstract class UpgradeEquipment : Upgrade, IEquipmentData
{
    [Header("General")]
    [SerializeField]
    private int id;
    private int level = 1;
    private bool isOpen = false;

    public EquipmentType equipmentType;

    public int Id { get => id; set => id = value; }
    public int Level { get => Mathf.Clamp(level, 1, 5); set => level = value; }
    public bool IsOpen { get => isOpen; set => isOpen = value; }
}