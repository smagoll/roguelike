using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EquipmentDynamic : Equipment
{
    private float startFrequency;
    public float scaleFrequency = 100;
    private float lastTimeAttack = 0f;

    public bool isAttack = false;

    public float Frequency { get => startFrequency * scaleFrequency / 100; set => startFrequency = value; }

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

    public abstract void Action();
}
