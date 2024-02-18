using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public IProjectileController projectileController;
    public Vector2 direction;
    public Vector2 startPosition;

    public void Flight()
    {
        transform.Translate(projectileController.SpeedFlight * Time.deltaTime * Vector2.up);
    }

    private void Start()
    {
        UpdateProjectile();
    }

    private void Update()
    {
        var distanceFlight = (new Vector2(transform.position.x, transform.position.y) - startPosition).magnitude;
        if (distanceFlight > projectileController.DistanceFlight)
        {
            DestroyProjectile();
        }
        Flight();
    }

    public void UpdateProjectile()
    {
        startPosition = transform.position;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
    }

    public virtual void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
