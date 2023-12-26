using UnityEngine;
using UnityEngine.Events;

public class GlobalEventManager : MonoBehaviour
{
    public static UnityEvent ChoiseBonus = new();
    public static UnityEvent<float> UpdateXp = new();

    public static void Start_ChoiseBonus()
    {
        ChoiseBonus.Invoke();
    }
        
    public static void Start_UpdateXp(float xp)
    {
        UpdateXp.Invoke(xp);
    }
}
