using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Attack
{
    public LayerMask layerEnemy;
    public float attackRange;

    public override void Action()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, attackRange, layerEnemy);
        foreach (var enemy in enemies)
        {
            var charEnemy = enemy.GetComponent<Enemy>();
            charEnemy.TakeDamage(damage);
        }
    }
}
