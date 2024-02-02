using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

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

    private void StartSpawn()
    {
        if (prefabsCloseEnemies.Count != 0)
        {
            isSpawn = true;
            StartCoroutine(Spawner());
        }
    }

    public IEnumerator Spawner()
    {
        while(isSpawn)
        {
            var position = Random.onUnitSphere * Random.Range(minRadius, maxRadius) + GameManager.player.transform.position;
            position.z = 0f;
            int randomEnemy = Random.Range(0, prefabsOpenEnemies.Count);
            Instantiate(prefabsOpenEnemies[randomEnemy], position, Quaternion.identity, enemiesTransform);
            yield return new WaitForSeconds(FrequencySpawn);
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
            if (closeEnemy.GetComponent<Enemy>().stageForOpen <= stage)
            {
                prefabsOpenEnemies.Add(closeEnemy);
                removeEnemies.Add(closeEnemy);
            }
        }

        foreach (var removeEnemy in removeEnemies)
        {
            prefabsCloseEnemies.Remove(removeEnemy);
        }
    }
}
