using UnityEngine;

public class Sword : Weapon
{
    private GameObject prefabSword;
    private GameObject swordObject;

    public float attackRange;

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
        Damage = dataSword.Damage;
        prefabSword = dataSword.prefabSword;
        swordObject = dataSword.prefabSwordObject;
        Frequency = dataSword.startFrequencyAttack;
        attackRange = dataSword.attackRange;
        upgrades = dataSword.upgrades;

        GlobalEventManager.Start_AddItem(dataSword);

        swordObject = Instantiate(prefabSword, gameObject.transform);
        swordObject.SetActive(false);
        swordObject.GetComponent<SwordObject>().sword = this;

        isAttack = true;
    }
}
