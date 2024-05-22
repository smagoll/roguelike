using System.Collections.Generic;
using System.Linq;
using Cinemachine;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    [Header("Stage")]
    private int numberStage = 1;
    public float xpForFirstStage; // необходимый опыт для первой стадии
    public float XpForCurrentStage => xpForFirstStage * numberStage; // необходимый опыт за текущую стадию
    private float xpCollect = 0; // собранный опыт за текущую стадию
    private int coin = 0;

    private static ContactFilter2D contactFilter2D = new();
    
    public int Coin
    {
        get => coin;
        set
        {
            coin = value;
            GlobalEventManager.Start_UpdateCoinGameText(coin);
        }
    }

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

    public int NumberStage
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
    public static Joystick joystick;
    public static LayerMask layerEnemy;
    public static LayerMask layerPlayer;

    private List<UpgradeAbility> upgradesAbility = new();
    public List<Upgrade> upgrades = new();

    [Inject]
    private void Construct(Character character, Joystick input)
    {
        player = character.gameObject;
        joystick = input;
    }

    private void Awake()
    {
        if (instance == null) instance = this;
        
        layerEnemy = LayerMask.GetMask("Enemy");
        layerPlayer = LayerMask.GetMask("Player");
        
        contactFilter2D.SetLayerMask(layerEnemy);
        contactFilter2D.useLayerMask = true;

        InitializeUpgrades();

        GlobalEventManager.UpdateXp.AddListener(UpdateXp);
        GlobalEventManager.IncreaseCoinGame.AddListener((int coins) => Coin += coins);
        GlobalEventManager.AddUpgrade.AddListener(AddUpgrade);
        GlobalEventManager.RemoveUpgrade.AddListener((Upgrade upgrade) => upgrades.Remove(upgrade));
    }

    private void Start()
    {
        GlobalEventManager.Start_UpdateCoinGameText(Coin);
        GlobalEventManager.Start_UpdateStageBar(numberStage, xpCollect, XpForCurrentStage);
    }

    public static GameObject GetCloseEnemy(Transform from, float radius)
    {
        float radiusCheck = 0;
        float closestDistance = Mathf.Infinity;
        GameObject closestEnemy = null;
        var enemies = new Collider2D[10];
        
        bool isFind = false;
        while (!isFind)
        {
            radiusCheck = Mathf.Clamp(radiusCheck + 1, float.MinValue, radius);
            var size = Physics2D.OverlapCircle(from.position, radiusCheck,contactFilter2D, enemies);
            if (size > 0 || radiusCheck == radius) isFind = true;
        }

        foreach (var enemy in enemies)
        {
            if (enemy == null) break;
            var distance = (from.transform.position - enemy.transform.position).sqrMagnitude;
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

        var heading = (closeEnemy.transform.position - from.position);
        var direction = heading / heading.magnitude;

        return direction;
    }

    private void UpdateXp(float xp)
    {
        XpCollect += xp;
    }

    public void AddUpgrade(Upgrade upgrade)
    {
        upgrades.Add(upgrade);
    }

    private void InitializeUpgrades()
    {
        foreach (var abilityData in DataManager.instance.gameData.abilities)
        {
            if (abilityData.IsOpen)
            {
                upgrades.Add(DataManager.instance.abilities.FirstOrDefault(x => x.Id == abilityData.id));
            }
        }
    }

    public static ObjectPool<T> CreatePool<T>(T obj) where T : MonoBehaviour
    {
        ObjectPool<T> pool = new(() =>
        {
            return Instantiate(obj);
        }, obj => {
            obj.gameObject.SetActive(true);
        }, obj => {
            obj.gameObject.SetActive(false);
        }, obj => {
            Destroy(obj);
        }, false);

        return pool;
    }

    public static ObjectPool<T> CreatePool<T>(T obj, Transform transform) where T : MonoBehaviour
    {
        ObjectPool<T> pool = new(() =>
        {
            return Instantiate(obj, transform);
        }, obj => {
            obj.gameObject.SetActive(true);
        }, obj => {
            obj.gameObject.SetActive(false);
        }, Destroy, false);

        return pool;
    }
}