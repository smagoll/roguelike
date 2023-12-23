using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int numberWave = 1;

    public static GameObject player;
    public static LayerMask layerEnemy;

    private void Awake()
    {
        GlobalEventManager.EndWave.AddListener(NextWaveCounter);
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        layerEnemy = LayerMask.NameToLayer("Enemy");
        GlobalEventManager.Start_NextWave();
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

    private void NextWaveCounter()
    {
        numberWave++;
    }
}
