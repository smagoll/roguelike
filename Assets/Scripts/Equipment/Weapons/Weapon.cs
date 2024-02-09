using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : EquipmentDynamic
{
    private float damage;
    public float scaleDamage = 100;

    public List<IEffectController> effectControllers = new();

    public float Damage { get => damage * scaleDamage / 100; set => damage = value; }
}
