using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float damage;
    private float startFrequency;
    public float scaleFrequency = 1;
    public float Frequency { get => startFrequency * scaleFrequency; set => startFrequency = value; }

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
