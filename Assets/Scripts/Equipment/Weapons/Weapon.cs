using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private float damage;
    public float scaleDamage = 100;
    private float startFrequency;
    public float scaleFrequency = 100;
    private float lastTimeAttack = 0f;

    public Upgrade[] upgrades;

    public bool isBleeding = false;
    public bool isAttack = false;

    public float Frequency { get => startFrequency * scaleFrequency / 100; set => startFrequency = value; }
    public float Damage { get => damage * scaleDamage / 100; set => damage = value; }

    private void Update()
    {
        if (isAttack)
        {
            if (Time.time - lastTimeAttack >= Frequency)
            {
                Action();
                lastTimeAttack = Time.time;
            }
        }
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

        isAttack = true;
    }

    public virtual void Action()
    {
        Debug.Log("action");
    }
}
