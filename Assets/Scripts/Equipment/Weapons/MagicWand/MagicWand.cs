using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicWand : Weapon
{
    [SerializeField]
    private GameObject prefabSphere;
    [SerializeField]
    public float attackRange;
    [SerializeField]
    private float radiusSphere;
    [SerializeField]
    private int countSphere;
    [SerializeField]
    public float speedFlight;
    [SerializeField]
    public float distanceFlight;

    public List<MagicWandSphere> spheres = new();

    public override void Action() { }

    public void SpawnSphere(int count)
    {
        for (int i = 0; i < count; i++)
        {
            var direction = GameCalculator.GetDirectionOnTheAngle(360f / countSphere);
            var position = new Vector3(direction.x, direction.y, 0f).normalized * radiusSphere;
            var sphereObject = Instantiate(prefabSphere, position, Quaternion.identity, transform);
            var sphere = sphereObject.GetComponent<MagicWandSphere>();
            sphere.Initialize(this);
            spheres.Add(sphere);
        }

        UpdateAngleSpheres();
    }

    public void UpdateAngleSpheres()
    {
        var angle = 360f / spheres.Count;
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

        SpawnSphere(countSphere);

        isAttack = true;
    }
}
