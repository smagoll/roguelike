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

    public bool isMove;

    private Transform target;
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
        hp = startHp;
    }

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        CheckIsMove();

        if (isMove)
        {
            MoveToPlayer();
        }
    }

    public void TakeDamage(float damage)
    {
        HP -= damage;
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
        foreach (var drop in drops)
        {
            Instantiate(drop, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
