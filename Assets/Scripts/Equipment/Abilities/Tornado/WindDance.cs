using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class WindDance : EquipmentDynamic
{
    public float damage;
    public float timeLifeTornado;
    public float frequencyChangeDirection;
    public float scaleSpeedFlight = 100;
    private float speedFlight;

    ObjectPool<Tornado> tornados;

    private int countTornado;

    public int CountTornado 
    { 
        get => countTornado;
        set
        {
            countTornado = value;
            scaleFrequency = 100 / countTornado;
        }
    }

    public float SpeedFlight { get => speedFlight * scaleSpeedFlight / 100; set => speedFlight = value; }


    public override void Action()
    {
        var tornado = tornados.Get();
        tornado.transform.position = transform.position;
        tornado.Initialize(damage, timeLifeTornado, frequencyChangeDirection, SpeedFlight, tornados);
    }

    public void Initialize(float damage, float timeLife, float frequency, float frequencyChangeDirection, float speedFlight, int countTornado, Upgrade[] upgrades, Tornado prefabTornado)
    {
        this.damage = damage;
        this.timeLifeTornado = timeLife;
        Frequency = frequency;
        this.frequencyChangeDirection = frequencyChangeDirection;
        this.speedFlight = speedFlight;
        CountTornado = countTornado;
        this.upgrades = upgrades;

        tornados = GameManager.CreatePool<Tornado>(prefabTornado);

        isAttack = true;
    }
}
