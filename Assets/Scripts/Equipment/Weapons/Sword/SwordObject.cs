using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordObject : MonoBehaviour
{
    public Sword sword;
    public Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        animator.SetTrigger("attack");       
    }

    public void DisableSword()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            var enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.TakeDamage(sword.Damage);
            
            if (sword.isBleeding)
            {
                Bleeding bleedingEnemy = enemy.GetComponent<Bleeding>();
            
                if (bleedingEnemy == null)
                {
                    bleedingEnemy = enemy.gameObject.AddComponent<Bleeding>();
                }
            
                bleedingEnemy.Damage = sword.Damage;
            }
        }
    }
}
