using UnityEngine;

public abstract class UpgradeAbility : Upgrade, IEquipmentData
{
    [SerializeField]
    private int id;
    [SerializeField]
    private int level;
    [SerializeField]
    private bool isOpen;

    public int Id { get => id; set => id = value; }
    public int Level { get => level; set => level = value; }
    public bool IsOpen { get => isOpen; set => isOpen = value; }
}
