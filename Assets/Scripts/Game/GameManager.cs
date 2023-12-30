using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Stage")]
    private static int numberStage = 1;
    public float xpForFirstStage; // необходимый опыт для первой стадии
    public float XpForCurrentStage => xpForFirstStage * Mathf.Pow(scaleStage, numberStage - 1); // необходимый опыт за текущую стадию
    private float xpCollect; // собранный опыт за текущую стадию
    public float scaleStage; // умножение необходимого опыта стадии при переходе на новую

    public float XpCollect
    {
        get { return xpCollect; }
        set
        {
            xpCollect = value;
            if (xpCollect >= XpForCurrentStage)
            {
                xpCollect -= XpForCurrentStage;
                NumberStage++;
            }
            GlobalEventManager.Start_UpdateStageBar(numberStage, xpCollect, XpForCurrentStage);
        }
    }

    public static int NumberStage
    {
        get { return numberStage; }
        set
        {
            numberStage = value;
            GlobalEventManager.Start_ShowUpgrades(upgrades);
            GlobalEventManager.Start_OpenEnemies(numberStage);
        }
    }

    [Header("Player")]
    public static GameObject player;
    public static LayerMask layerEnemy;
    public static LayerMask layerPlayer;

    public List<Upgrade> upgradesWeapon;
    public List<Upgrade> upgradesAbility;
    public static List<Upgrade> upgrades = new();

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        layerEnemy = LayerMask.GetMask("Enemy");
        layerPlayer = LayerMask.GetMask("Player");

        GlobalEventManager.UpdateXp.AddListener(UpdateXp);
    }

    private void Start()
    {
        GlobalEventManager.Start_UpdateStageBar(numberStage, xpCollect, XpForCurrentStage);
        GlobalEventManager.Start_ShowUpgrades(upgradesWeapon);
    }

    public static GameObject GetCloseEnemy(Transform from, float radius)
    {
        float closestDistance = Mathf.Infinity;
        GameObject closestEnemy = null;
        Collider2D[] enemies = Physics2D.OverlapCircleAll(from.position, radius, layerEnemy);

        foreach (var enemy in enemies)
        {
            var distance = (player.transform.position - enemy.transform.position).sqrMagnitude;
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestEnemy = enemy.gameObject;
            }
        }
        return closestEnemy;
    }

    public static Vector3 GetDirectionToCloseEnemy(Transform from, float radius)
    {
        var closeEnemy = GetCloseEnemy(from, radius);
        if (closeEnemy == null)
        {
            return Vector3.zero;
        }

        var heading = (closeEnemy.transform.position - player.transform.position);
        var direction = heading / heading.magnitude;

        return direction;
    }

    private void UpdateXp(float xp)
    {
        XpCollect += xp;
    }

    public static void AddUpgrade(Upgrade upgrade)
    {
        upgrades.Add(upgrade);
    }
}
