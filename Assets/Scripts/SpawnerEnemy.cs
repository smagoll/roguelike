using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class SpawnerEnemy : MonoBehaviour
{
    public List<GameObject> prefabsEnemies;
    public float CountEnemyWave => GameManager.numberWave * 5;
    private float counterEnemySpawn;

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

    private readonly float frequencySpawn = 1f;

    private void Awake()
    {
        GlobalEventManager.NextWave.AddListener(StartSpawn);
        GlobalEventManager.DeathEnemy.AddListener(SubtractCounter);
    }

    private void Update()
    {
        if (counterEnemySpawn == 0)
        {
            GlobalEventManager.Start_EndWave();
        }
    }

    private void StartSpawn()
    {
        StartCoroutine(Spawner());
    }

    public IEnumerator Spawner()
    {
        for (int i = 0; i < CountEnemyWave; i++)
        {
            Instantiate(prefabsEnemies[0]);
            CounterEnemySpawn++;
            yield return new WaitForSeconds(frequencySpawn);
        }
    }

    private void SubtractCounter()
    {
        CounterEnemySpawn--;
    }
}
