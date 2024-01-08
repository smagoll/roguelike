using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private float damage;
    public float scaleDamage = 100;
    private float startFrequency;
    public float scaleFrequency = 100;

    public bool isBleeding = false;

    public float Frequency { get => startFrequency * scaleFrequency / 100; set => startFrequency = value; }
    public float Damage { get => damage * scaleDamage / 100; set => damage = value; }

    public virtual void StartAttack()
    {
        StartCoroutine(ActionPerFreq());
    }

    public virtual void Action()
    {
        Debug.Log("action");
    }

    IEnumerator ActionPerFreq()
    {
        while (Application.isPlaying)
        {
            yield return new WaitForSecondsRealtime(Frequency);

            Action();
        }
    }
}
