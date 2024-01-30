using UnityEngine;

public abstract class Weapon : EquipmentDynamic
{
    private float damage;
    public float scaleDamage = 100;

    public bool isBleeding = false;

    public float Damage { get => damage * scaleDamage / 100; set => damage = value; }
}
