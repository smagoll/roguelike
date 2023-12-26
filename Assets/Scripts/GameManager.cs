using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Stage")]
    private int numberStage = 1;
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
            textXp.text = $"{xpCollect}/{XpForCurrentStage}";
        }
    }

    public int NumberStage
    {
        get { return numberStage; }
        set
        {
            numberStage = value;
            GlobalEventManager.Start_ChoiseBonus();
            textNumberStage.text = $"Stage {numberStage}";
        }
    }

    [Header("Player")]
    public static GameObject player;
    public static LayerMask layerEnemy;

    [SerializeField]
    private TextMeshProUGUI textXp;
    [SerializeField]
    private TextMeshProUGUI textNumberStage;

    private void Awake()
    {
        GlobalEventManager.UpdateXp.AddListener(UpdateXp);
        textXp.text = $"{xpCollect}/{XpForCurrentStage}";
        textNumberStage.text = $"Stage {numberStage}";
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        layerEnemy = LayerMask.NameToLayer("Enemy");
    }

    public static Enemy GetCloseEnemy(Transform from, float radius)
    {
        float closestDistance = Mathf.Infinity;
        Enemy closestEnemy = null;

        Collider2D[] enemies = Physics2D.OverlapCircleAll(from.position, radius, layerEnemy);
        foreach (var enemy in enemies)
        {
            if (enemy != null)
            {
                var distance = (player.transform.position - enemy.transform.position).sqrMagnitude;
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestEnemy = enemy.GetComponent<Enemy>();
                }
            }
        }
        return closestEnemy;
    }

    private void UpdateXp(float xp)
    {
        XpCollect += xp;
    }
}
