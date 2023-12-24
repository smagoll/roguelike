using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class SpawnerEnemy : MonoBehaviour
{
    public List<GameObject> prefabsEnemies;
    public float MaxCountEnemyWave => GameManager.numberWave * 5;
    private float remainderEnemyWave; // остаток врагов в волне
    private float counterEnemySpawn;

    [SerializeField]
    private float minRadius;
    [SerializeField]
    private float maxRadius;

    public static bool isSpawn;
    private bool isAliveEnemy = false;

    [SerializeField]
    private TextMeshProUGUI counterEnemyUI;
    public float CounterEnemySpawn
    {
        get { return counterEnemySpawn; }
        set
        {
            counterEnemySpawn = value;
            counterEnemyUI.text = counterEnemySpawn.ToString();
        }
    }

    [SerializeField]
    private float frequencySpawn;

    private void Awake()
    {
        GlobalEventManager.NextWave.AddListener(StartSpawn);
        GlobalEventManager.EndWave.AddListener(() => isSpawn = false);
        GlobalEventManager.DeathEnemy.AddListener(SubtractCounter);
    }

    private void Update()
    {
        isAliveEnemy = !(counterEnemySpawn == 0 && remainderEnemyWave == 0);

        if (!isAliveEnemy && isSpawn)
        {
            GlobalEventManager.Start_EndWave();
        }
    }

    private void StartSpawn()
    {
        isSpawn = true;
        StartCoroutine(Spawner());
    }

    public IEnumerator Spawner()
    {
        remainderEnemyWave = MaxCountEnemyWave;
        while(remainderEnemyWave > 0)
        {
            Instantiate(prefabsEnemies[0], Random.onUnitSphere * Random.Range(minRadius, maxRadius) + GameManager.player.transform.position, Quaternion.identity);
            remainderEnemyWave--;
            CounterEnemySpawn++;
            yield return new WaitForSeconds(frequencySpawn);
            Debug.Log(remainderEnemyWave);
        }
    }

    private void SubtractCounter() // вычитание счетчика
    {
        CounterEnemySpawn--;
    }
}
