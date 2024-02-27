using System.Linq;
using UnityEngine;

public class Gravity : Effect
{
    private GameObject effectObject;

    private float startSpeed;
    private float Slowdown => stats.FirstOrDefault(x => x.Type == StatType.Slowdown).GetValue();
    private float ExplosionRadius => stats.FirstOrDefault(x => x.Type == StatType.Radius).GetValue();
    public override void ActionStart()
    {
        effectObject = EffectManager.instance.CreateGravityEffect(enemy.transform);
        startSpeed = enemy.Speed;
        enemy.Speed = startSpeed * (100 - Slowdown) / 100;
    }
    
    public override void ActionEnd()
    {
        if (effectObject != null) Destroy(effectObject);
        EffectManager.instance.CreateGravityExplosion(transform);
        enemy.Speed = startSpeed;
        var enemies = Physics2D.OverlapCircleAll(transform.position, ExplosionRadius, GameManager.layerEnemy);
        if (enemies.Length > 0)
        {
            foreach (var enemy in enemies)
            {
                enemy.GetComponent<Enemy>().TakeDamage(weapon.Damage);
            }
        }

    }

    private void OnDestroy()
    {
        
    }
}