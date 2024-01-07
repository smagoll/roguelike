using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityDynamic : Ability
{
    private float startFrequency;
    public float scaleFrequency = 1;
    public PlayerController playerController;
    public Upgrade[] upgrades;
    public float Frequency { get => startFrequency * scaleFrequency; set => startFrequency = value; }

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    public virtual void StartAttack()
    {
        if (upgrades.Length > 0)
        {
            foreach (var upgrade in upgrades)
            {
                GameManager.AddUpgrade(upgrade);
            }
        }

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
