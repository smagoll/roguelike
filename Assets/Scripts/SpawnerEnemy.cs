using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class SpawnerEnemy : MonoBehaviour
{
    public List<GameObject> prefabsEnemies;

    [SerializeField]
    private float minRadius;
    [SerializeField]
    private float maxRadius;

    public static bool isSpawn;

    [SerializeField]
    private float frequencySpawn;

    private void Start()
    {
        StartSpawn();
    }

    private void StartSpawn()
    {
        isSpawn = true;
        StartCoroutine(Spawner());
    }

    public IEnumerator Spawner()
    {
        while(isSpawn)
        {
            var position = Random.onUnitSphere * Random.Range(minRadius, maxRadius) + GameManager.player.transform.position;
            position.z = 0f;
            Instantiate(prefabsEnemies[0], position, Quaternion.identity);
            yield return new WaitForSeconds(frequencySpawn);
        }
    }
}
