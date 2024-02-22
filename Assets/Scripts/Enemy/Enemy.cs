using UnityEngine;
using UnityEngine.Pool;

public class Enemy : MonoBehaviour
{
    public ObjectPool<Enemy> pool;

    [SerializeField]
    private float startHp;
    private float hp;
    public float scaleHp;
    public float xp;
    public float speed;
    public float distanceStop;

    public float damage;
    public float freqAttack;
    public float lastAttackTime = 0f;

    public bool isMove;
    public bool isDeath;

    private Transform target;

    public int stageForOpen;

    public GameObject[] drops;
    public Animator animator;
    public ParticleSystem hit;

    public float HP
    {
        get { return hp; }
        set
        {
            hp = value;
            if (hp <= 0f)
            {
                Death();
            }
        }
    }
    public float Speed { get => speed * 100; set => speed = value / 100; }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        UpdateStats();
        target = GameManager.player.transform;
    }

    private void Update()
    {
        if (isDeath)
        {
            return;
        }

        CheckIsMove();

        if (isMove)
        {
            MoveToPlayer();
        }
        else
        {
            if (Time.time - lastAttackTime > freqAttack)
            {
                animator.SetTrigger("attack");
                lastAttackTime = Time.time;
            }
        }
    }

    public void TakeDamage(float damage)
    {
        HP -= damage;
        GlobalEventManager.Start_CreateDamageHurt(transform.position, damage, TextHit.Default);
        EffectEventManager.Start_CreateHit(transform);
    }
    
    public void TakeDamage(float damage, IEffectController[] effectControllers)
    {
        HP -= damage;

        GlobalEventManager.Start_CreateDamageHurt(transform.position, damage, TextHit.Default);
        EffectEventManager.Start_CreateHit(transform);

        foreach (var effectController in effectControllers)
        {
            effectController.AddEffect(this);
        }
    }
    
    public void TakeDamage(float damage, TextHit textHit)
    {
        HP -= damage;
        GlobalEventManager.Start_CreateDamageHurt(transform.position, damage, textHit);
        EffectEventManager.Start_CreateHit(transform);
    }

    private void MoveToPlayer()
    {
        var direction = target.position - transform.position;
        transform.position += speed * Time.deltaTime * direction.normalized;
    }

    private Vector3 DirectionToTarget()
    {
        return target.position - transform.position;
    }

    private float DistanceToTarget()
    {
        var direction = DirectionToTarget();
        return direction.magnitude;
    }

    private void CheckIsMove()
    {
        var distance = DistanceToTarget();
        if (distance <= distanceStop)
        {
            isMove = false;
        }
        else
        {
            isMove = true;
        }
    }

    private void Death()
    {
        isDeath = true;
        GetComponent<CircleCollider2D>().enabled = false;
        animator.SetTrigger("death");
    }

    public void DestroyEnemy()
    {
        AppearanceDrops();
        UpdateStats();
        pool.Release(this);
    }
      
    private void UpdateStats()
    {  
        HP = startHp * scaleHp;
        isDeath = false;
        GetComponent<CircleCollider2D>().enabled = true;

        var effects = GetComponents<Effect>();
        if(effects.Length > 0)
            foreach (var effect in effects) Destroy(effect);
    }
    
    public virtual void Attack()
    {
        var players = Physics2D.OverlapCircleAll(gameObject.transform.position, distanceStop);
        foreach (var player in players)
        {
            if (player.CompareTag("Player"))
            {
                var character = player.GetComponent<Character>();
                character.TakeDamage(damage);
            }
        }
    }

    public void AppearanceDrops()
    {
        foreach (var drop in drops)
        {
            var randomNumber = Random.Range(0, 100);
            if (randomNumber <= drop.GetComponent<Drop>().chance)
            {
                Instantiate(drop, transform.position, Quaternion.identity);
            }
        }
    }
}
