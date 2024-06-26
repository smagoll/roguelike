using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{
    public Hero hero;
    private float maxHp;
    private float hp;
    private float speed;
    private float evasion;
    private float scaleHp = 1;
    private float scaleSpeed = 1;
    public Animator animator;
    public DropCollector dropCollector;
    public UpgradeWeapon weapon;

    public Upgrade[] upgrades;

    public float MaxHP => Mathf.Round(maxHp * scaleHp);

    public float HP
    {
        get => hp;
        set
        {
            if (value > 0 && value <= MaxHP)
            {
                hp = Mathf.Round(value);
            }
            if (value <= 0)
            {
                GlobalEventManager.Start_UpdateHealthBar(0, MaxHP);
                Death();
            }
            GlobalEventManager.Start_UpdateHealthBar(HP, MaxHP);
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
    public float Evasion { get => evasion; set => evasion = value; }

    private void Awake()
    {
        hero = DataManager.instance.GetEquipmentHero();
        animator = GetComponent<Animator>();
        InitializeStats();
        HP = maxHp;

        GlobalEventManager.IncreaseHP.AddListener(IncreaseHP);
    }

    private void Start()
    {
        foreach (var upgrade in upgrades)
        {
            GlobalEventManager.Start_AddUpgrade(upgrade);
        }

        GlobalEventManager.Start_UpdateHealthBar(HP, MaxHP);
        weapon.Action();
    }

    public void TakeDamage(float damage)
    {
        var rnd = Random.Range(0, 100);
        if (rnd > evasion)
        {
            HP -= damage;
            animator.SetTrigger("hurt");
            AudioGame.instance.PlayMainSFX(AudioGame.instance.playerDamage);
            CinemachineShake.Instance.ShakeCamera(2f, .1f);
            CinemachineShake.Instance.ShowDamageBackground();
        }
        else
        {
            AudioGame.instance.PlayMainSFX(AudioGame.instance.playerMiss);
            GlobalEventManager.Start_CreateEvade(transform.position);
        }
    }

    public void Death()
    {
        GlobalEventManager.Start_EndGame();
    }

    private void IncreaseHP(float hp)
    {
        HP += hp;
    }

    private void InitializeStats()
    {
        GetComponent<SpriteRenderer>().sprite = hero.sprite;
        animator.runtimeAnimatorController = hero.animator;
        maxHp = hero.Hp;
        speed = hero.Speed;
        evasion = hero.Evasion;
        weapon = hero.weapon;
    }
}
