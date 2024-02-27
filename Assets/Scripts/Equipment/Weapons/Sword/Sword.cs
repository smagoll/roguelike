using UnityEngine;

public class Sword : Weapon
{
    private GameObject prefabSword;
    public GameObject swordObject;

    private float scaleAttackRange = 100;
    public float ScaleAttackRange
    {
        get
        {
            return scaleAttackRange;
        }
        set
        {
            scaleAttackRange = value;
            swordObject.GetComponent<SwordObject>().UpdateScale(scaleAttackRange);
        }
    }
    private float attackRange;

    public float AttackRange { get => attackRange * scaleAttackRange / 100; set => attackRange = value; }

    private PlayerController playerController;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    public override void Action()
    {
        RotationToCloseEnemy();
        swordObject.SetActive(true);
    }

    private void RotationToCloseEnemy()
    {
        var direction = GameManager.GetDirectionToCloseEnemy(transform, AttackRange * 2);
        if (direction.magnitude == 0)
        {
            direction = playerController.directionLook;
        }
        Vector3 positionAttack = gameObject.transform.position + direction * AttackRange / 2 * 1.5f;
        swordObject.transform.position = positionAttack;
    }

    public void Initialize(UpgradeAddSword dataSword)
    {
        Damage = dataSword.Damage;
        prefabSword = dataSword.prefabSword;
        swordObject = dataSword.prefabSwordObject;
        Frequency = dataSword.startFrequencyAttack;
        attackRange = dataSword.attackRange;
        upgrades = dataSword.upgrades;

        swordObject = Instantiate(prefabSword, gameObject.transform);
        swordObject.SetActive(false);
        swordObject.GetComponent<SwordObject>().sword = this;

        isAttack = true;
    }
}
