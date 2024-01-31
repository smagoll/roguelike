using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordObject : MonoBehaviour
{
    public Sword sword;
    public Animator animator;
    public Collider2D collider2d;
    private ContactFilter2D filter;
    private Vector3 scale;

    private void Awake()
    {
        scale = transform.localScale;
        animator = GetComponent<Animator>();
        collider2d = GetComponent<Collider2D>();
        filter = new ContactFilter2D();
        filter.SetLayerMask(GameManager.layerEnemy);
        filter.useLayerMask = true;
        filter.useTriggers = true;
    }

    private void OnEnable()
    {
        animator.SetTrigger("attack");
        Attack();
    }

    public void DisableSword()
    {
        gameObject.SetActive(false);
    }

    public void Attack()
    {
        List<Collider2D> results = new();

        collider2d.OverlapCollider(filter, results);

        foreach (var result in results)
        {
            var enemy = result.gameObject.GetComponent<Enemy>();
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

    public void UpdateScale(float scaleScale)
    {
        transform.localScale = scale *  (scaleScale)/ 100;
    }
}
