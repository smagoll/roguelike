using UnityEngine;

public class Sword : Weapon
{
    private GameObject prefabSword;
    private GameObject swordObject;

    public float attackRange;

    public Upgrade[] upgrades;

    private PlayerController playerController;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    public override void StartAttack()
    {
        swordObject = Instantiate(prefabSword, gameObject.transform);
        swordObject.SetActive(false);

        foreach (var upgrade in upgrades)
        {
            GameManager.AddUpgrade(upgrade);
        }

        base.StartAttack();
    }

    public override void Action()
    {
        RotationToCloseEnemy();
        swordObject.SetActive(true);
        var enemies = Physics2D.OverlapCircleAll(swordObject.transform.position, attackRange, GameManager.layerEnemy);

        foreach (var enemy in enemies)
        {
            var qwe = enemy.GetComponent<Enemy>();
            qwe.TakeDamage(Damage);
        }
    }

    private void RotationToCloseEnemy()
    {
        var direction = GameManager.GetDirectionToCloseEnemy(transform, attackRange * 2);
        if (direction.magnitude == 0)
        {
            direction = playerController.directionLook;
        }
        Vector3 positionAttack = gameObject.transform.position + direction * attackRange;
        swordObject.transform.position = positionAttack;
    }

    public void Initialize(UpgradeAddSword dataSword)
    {
        Damage = dataSword.damage;
        prefabSword = dataSword.prefabSword;
        swordObject = dataSword.prefabSwordObject;
        Frequency = dataSword.startFrequencyAttack;
        attackRange = dataSword.attackRange;
        upgrades = dataSword.upgrades;

        GlobalEventManager.Start_AddItem(dataSword);

        StartAttack();
    }
}
