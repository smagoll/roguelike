using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicWand : Weapon
{
    [SerializeField]
    private GameObject prefabSphere;
    [SerializeField]
    private float attackRange;
    [SerializeField]
    private float radiusSphere;
    [SerializeField]
    private int countSphere;
    [SerializeField]
    private float speedFlight;
    [SerializeField]
    private float distanceFlight;

    public List<MagicWandSphere> spheres = new();

    public override void Action()
    {

    }

    public void SpawnSphere()
    {
        var direction = GameCalculator.GetDirectionOnTheAngle(360f / countSphere);
        var position = new Vector3(direction.x, direction.y, 0f).normalized * radiusSphere;
        var sphereObject = Instantiate(prefabSphere, position, Quaternion.identity, transform);
        var sphere = sphereObject.GetComponent<MagicWandSphere>();
        sphere.Initialize(speedFlight, distanceFlight, Frequency, Damage, attackRange);
        spheres.Add(sphere);
        UpdateAngleSpheres();
    }

    public void UpdateAngleSpheres()
    {
        var angle = 360f / countSphere;
        float localAngle = 0;
        foreach (var sphere in spheres)
        {
            var direction = GameCalculator.GetDirectionOnTheAngle(localAngle);
            sphere.transform.localPosition = new Vector3(direction.x, direction.y, 0f).normalized * radiusSphere;
            localAngle += angle;
        }
    }

    public void Initialize(GameObject prefabSphere, float attackRange, float radius, int countSphere, float speedFlight, float distanceFlight, float damage, float frequency, Upgrade[] upgrades)
    {
        this.prefabSphere = prefabSphere;
        this.attackRange = attackRange;
        radiusSphere = radius;
        this.countSphere = countSphere;
        this.speedFlight = speedFlight;
        this.distanceFlight = distanceFlight;
        Damage = damage;
        Frequency = frequency;
        this.upgrades = upgrades;

        for (int i = 0; i < countSphere; i++)
        {
            SpawnSphere();
        }

        isAttack = true;
    }
}
