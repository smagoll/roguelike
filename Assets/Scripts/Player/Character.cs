using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Hero hero;
    private float maxHp;
    private float hp;
    private float speed;
    private float scaleHp = 1;
    private float scaleSpeed = 1;
    public Animator animator;

    public Upgrade[] upgrades;

    public float MaxHP => maxHp * scaleHp;

    public float HP
    {
        get => hp;
        set
        {
            if (value > 0 && value <= MaxHP)
            {
                hp = Mathf.Round(value);
                GlobalEventManager.Start_UpdateHealthBar(HP, MaxHP);
            }
            if (hp <= 0)
            {
                Death();
            }
        }
    }

    public float Speed => speed * scaleSpeed;
    public float ScaleSpeed { get => scaleSpeed * 100; set => scaleSpeed = value / 100; }
    public float ScaleHp
    {
        get { return scaleHp * 100; }
        set
        {
            scaleHp = value / 100;
            GlobalEventManager.Start_UpdateHealthBar(HP, MaxHP);
        }
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        InitializeStats();
        HP = maxHp;

        GlobalEventManager.IncreaseHP.AddListener(IncreaseHP);

        foreach (var upgrade in upgrades)
        {
            GameManager.AddUpgrade(upgrade);
        }

    }

    private void Start()
    {
        GlobalEventManager.Start_UpdateHealthBar(hp, maxHp);
    }

    public void TakeDamage(float damage)
    {
        HP -= damage;
        animator.SetTrigger("hurt");
    }
    
    public void TakeDamage(float damage, TextHit textHit)
    {
        HP -= damage;
        animator.SetTrigger("hurt");
    }

    public void Death()
    {
        Debug.Log("death");
    }

    private void IncreaseHP(float hp)
    {
        HP += hp;
    }

    private void InitializeStats()
    {
        GetComponent<SpriteRenderer>().sprite = hero.sprite;
        animator.runtimeAnimatorController = hero.animator;
        maxHp = hero.hp;
        speed = hero.speed;
    }
}
