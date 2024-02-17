using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Pool;

public class SpawnerEnemy : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;
    [SerializeField]
    private Transform enemiesTransform;

    public List<GameObject> prefabsCloseEnemies = new();
    public List<GameObject> prefabsOpenEnemies = new();

    [SerializeField]
    private float minRadius;
    [SerializeField]
    private float maxRadius;

    public static bool isSpawn;

    [SerializeField]
    private float frequencySpawn;
    private float lastTimeSpawn = 0;

    private List<ObjectPool<Enemy>> objectPools = new();

    [SerializeField]
    private float percentIncreaseHP;
    private float ScaleHpEnemy => Mathf.Pow(1 + percentIncreaseHP / 100, gameManager.NumberStage - 1);

    public float FrequencySpawn
    {
        get => frequencySpawn - gameManager.NumberStage * 0.01f;
    }

    private void Awake()
    {
        GlobalEventManager.OpenEnemies.AddListener(OpenEnemies);
    }

    private void Start()
    {
        OpenEnemies(gameManager.NumberStage);
        StartSpawn();
    }

    private void Update()
    {
        if (isSpawn)
        {
            if (Time.time - lastTimeSpawn >= FrequencySpawn)
            {
                var position = Random.onUnitSphere * Random.Range(minRadius, maxRadius) + GameManager.player.transform.position;
                position.z = 0f;
                int rndPool = Random.Range(0, objectPools.Count);
                var enemy = objectPools[rndPool].Get();
                enemy.transform.position = position;
                enemy.pool = objectPools[rndPool];
                enemy.scaleHp = ScaleHpEnemy;
                lastTimeSpawn = Time.time;
            }
        }
    }

    private void StartSpawn()
    {
        if (prefabsCloseEnemies.Count != 0)
        {
            isSpawn = true;
        }
    }


    private void OpenEnemies(int stage)
    {

        if (prefabsCloseEnemies.Count == 0)
        {
            return;
        }

        var removeEnemies = new List<GameObject>();

        foreach (var closeEnemy in prefabsCloseEnemies)
        {
            var enemy = closeEnemy.GetComponent<Enemy>();
            if (enemy.stageForOpen <= stage)
            {
                objectPools.Add(CreatePool(enemy));
            }
        }

        foreach (var removeEnemy in removeEnemies)
        {
            prefabsCloseEnemies.Remove(removeEnemy);
        }
    }

    private ObjectPool<Enemy> CreatePool(Enemy enemy)
    {
        ObjectPool<Enemy> pool = new(() =>
        {
            return Instantiate(enemy, enemiesTransform);
        }, enemy => {
            enemy.gameObject.SetActive(true);
        }, enemy => {
            enemy.gameObject.SetActive(false);
        }, enemy => {
            enemy.DestroyEnemy();
        }, false);

        return pool;
    }
}
