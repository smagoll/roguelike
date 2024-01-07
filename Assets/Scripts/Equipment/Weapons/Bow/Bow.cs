using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : Weapon, IProjectileController
{
    public GameObject prefabArrow;
    public bool isArrowThrough = false;

    public float attackRange;

    public Upgrade[] upgrades;

    private PlayerController playerController;

    public float DistanceFlight { get; set; }
    public float SpeedFlight { get; set; }

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    public override void StartAttack()
    {
        if (upgrades.Length > 0)
        {
            foreach (var upgrade in upgrades)
            {
                GameManager.AddUpgrade(upgrade);
            }
        }


        base.StartAttack();
    }

    public override void Action()
    {
        var direction = GameManager.GetDirectionToCloseEnemy(transform, attackRange);
        var arrowObject = Instantiate(prefabArrow, gameObject.transform.position, Quaternion.identity);
        var arrow = arrowObject.GetComponent<Arrow>();
        arrow.bow = this;
        arrow.projectileController = this;
        arrow.IsThrough = isArrowThrough;

        if (direction == Vector3.zero)
        {
            arrow.direction = playerController.directionLook;
        }
        else
        {
            arrow.direction = direction;
        }
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

        StartAttack();
    }
}
