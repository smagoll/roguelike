using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public string title;
    public float damage;
    [SerializeField]
    private float startFrequency;
    public float scaleFrequency;
    public float frequency;

    private void Start()
    {
        frequency = startFrequency;
        StartCoroutine(ActionPerFreq());
    }

    public virtual void Action()
    {
        Debug.Log(title + " action");
    }

    IEnumerator ActionPerFreq()
    {
        while (Application.isPlaying)
        {
            yield return new WaitForSecondsRealtime(frequency * scaleFrequency);

            Action();
        }
    }
}
