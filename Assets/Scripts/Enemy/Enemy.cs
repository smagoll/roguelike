using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float startHp;
    private float hp;
    public float xp;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float distanceStop;

    public float damage;
    public float freqAttack;
    public float lastAttackTime = 0f;

    public bool isMove;

    private Transform target;

    public int stageForOpen;

    public GameObject[] drops;

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
        HP = startHp;
    }

    private void Start()
    {
        target = GameManager.player.transform;
    }

    private void Update()
    {
        CheckIsMove();

        if (isMove)
        {
            MoveToPlayer();
        }
        else
        {
            if (Time.time - lastAttackTime > freqAttack)
            {
                Attack();
                lastAttackTime = Time.time;
            }
        }
    }

    public void TakeDamage(float damage)
    {
        HP -= damage;
        GlobalEventManager.Start_CreateDamageHurt(transform.position, damage);
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

    public void Death()
    {
        AppearanceDrops();
        Destroy(gameObject);
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
