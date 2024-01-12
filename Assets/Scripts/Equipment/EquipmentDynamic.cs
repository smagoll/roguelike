using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentDynamic : Equipment
{
    private float startFrequency;
    public float scaleFrequency = 100;
    private float lastTimeAttack = 0f;

    public Upgrade[] upgrades;

    public float Frequency { get => startFrequency * scaleFrequency / 100; set => startFrequency = value; }

    public bool isAttack = false;

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

    public virtual void Action()
    {
        Debug.Log("action");
    }

    private void Start()
    {
        if (upgrades.Length > 0)
        {
            foreach (var upgrade in upgrades)
            {
                GameManager.AddUpgrade(upgrade);
            }
        }
    }
}
