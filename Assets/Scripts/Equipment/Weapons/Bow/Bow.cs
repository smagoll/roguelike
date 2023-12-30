using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : Weapon
{
    public GameObject prefabArrow;
    public float attackRange;
    public float distanceFlight;
    public float speedFlightArrow;

    public Upgrade[] upgrades;

    private PlayerController playerController;

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
        if (direction == Vector3.zero)
        {
            arrow.direction = playerController.directionLook;
        }
        else
        {
            arrow.direction = direction;
        }
    }

    public void Initialaze(UpgradeAddBow dataBow)
    {
        prefabArrow = dataBow.prefabSword;
        damage = dataBow.damage;
        speedFlightArrow = dataBow.speedFlightArrow;
        attackRange = dataBow.attackRange;
        Frequency = dataBow.startFrequencyAttack;
        upgrades = dataBow.upgrades;
        distanceFlight = dataBow.distanceFlight;

        StartAttack();
    }
}
