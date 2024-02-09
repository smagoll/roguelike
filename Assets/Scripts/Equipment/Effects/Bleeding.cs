using System.Linq;
using UnityEngine;

public class Bleeding : Effect
{
    private float damagePerSecond;
    private float frequency;
    private float lastTimeTick;

    public float Damage
    {
        set => damagePerSecond = value / 10f;
    }

    public override void ActionStart()
    {
        lastTimeTick = Time.time;
        Damage = weapon.Damage;
        frequency = stats.FirstOrDefault(x => x.Type == StatType.Frequency).GetValue();
    }

    public override void ActionUpdate()
    {
        if (Time.time - lastTimeTick >= frequency)
        {
            enemy.TakeDamage(damagePerSecond, TextHit.Small);
            lastTimeTick = Time.time;
        }
    }
}