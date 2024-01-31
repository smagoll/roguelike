using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindDance : EquipmentDynamic
{
    public GameObject prefabTornado;

    public float damage;
    public float timeLifeTornado;
    public float frequencyChangeDirection;
    public float scaleSpeedFlight = 100;
    private float speedFlight;

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
        var tornadoObject = Instantiate(prefabTornado, transform.position, Quaternion.identity);
        var tornado = tornadoObject.GetComponent<Tornado>();
        tornado.Initialize(damage, timeLifeTornado, frequencyChangeDirection, SpeedFlight);
    }

    public void Initialize(float damage, float timeLife, float frequency, float frequencyChangeDirection, float speedFlight, int countTornado, Upgrade[] upgrades, GameObject prefabTornado)
    {
        this.damage = damage;
        this.timeLifeTornado = timeLife;
        Frequency = frequency;
        this.frequencyChangeDirection = frequencyChangeDirection;
        this.speedFlight = speedFlight;
        CountTornado = countTornado;
        this.upgrades = upgrades;
        this.prefabTornado = prefabTornado;

        isAttack = true;
    }
}
