using UnityEngine;
using UnityEngine.Events;

public class GlobalEventManager : MonoBehaviour
{
    public static UnityEvent NextWave = new();
    public static UnityEvent EndWave = new();
    public static UnityEvent DeathEnemy = new();

    public static void Start_NextWave()
    {
        NextWave.Invoke();
    }
    
    public static void Start_EndWave()
    {
        EndWave.Invoke();
    }
    
    public static void Start_DeathEnemy()
    {
        DeathEnemy.Invoke();
    }
}
