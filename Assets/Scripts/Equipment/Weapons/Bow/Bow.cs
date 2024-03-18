using UnityEngine;
using UnityEngine.Pool;

public class Bow : Weapon, IProjectileController
{
    private ObjectPool<Arrow> arrows;
    
    public GameObject prefabArrow;
    public bool isArrowThrough = false;

    public float attackRange;

    private PlayerController playerController;

    public float DistanceFlight { get; set; }
    public float SpeedFlight { get; set; }
    public Vector2 Direction { get; set; }

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    public override void Action()
    {
        Direction = GameManager.GetDirectionToCloseEnemy(transform, attackRange);
        var arrow = arrows.Get();
        arrow.transform.position = transform.position;
        arrow.Initialize(this, isArrowThrough, arrows);

        if (Direction == Vector2.zero)
            arrow.direction = playerController.directionLook;
        else
            arrow.direction = Direction;
        
        arrow.StartFlight();
    }

    public void Initialize(UpgradeAddBow dataBow)
    {
        Damage = dataBow.Damage;
        SpeedFlight = dataBow.speedFlightArrow;
        attackRange = dataBow.attackRange;
        Frequency = dataBow.Frequency;
        upgrades = dataBow.upgrades;
        DistanceFlight = dataBow.distanceFlight;
        arrows = GameManager.CreatePool<Arrow>(dataBow.prefabArrow);

        isAttack = true;
    }
}
