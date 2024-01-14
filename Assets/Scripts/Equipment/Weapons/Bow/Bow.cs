using UnityEngine;

public class Bow : Weapon, IProjectileController
{
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
        var arrowObject = Instantiate(prefabArrow, gameObject.transform.position, Quaternion.identity);
        var arrow = arrowObject.GetComponent<Arrow>();
        arrow.bow = this;
        arrow.projectileController = this;
        arrow.IsThrough = isArrowThrough;

        if (Direction == Vector2.zero)
            arrow.direction = playerController.directionLook;
        else
            arrow.direction = Direction;
    }

    public void Initialize(UpgradeAddBow dataBow)
    {
        prefabArrow = dataBow.prefabSword;
        Damage = dataBow.damage;
        SpeedFlight = dataBow.speedFlightArrow;
        attackRange = dataBow.attackRange;
        Frequency = dataBow.frequency;
        upgrades = dataBow.upgrades;
        DistanceFlight = dataBow.distanceFlight;

        GlobalEventManager.Start_AddItem(dataBow);

        isAttack = true;
    }
}
