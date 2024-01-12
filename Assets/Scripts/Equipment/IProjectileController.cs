using UnityEngine;

public interface IProjectileController
{
    public float DistanceFlight { get; set; }
    public float SpeedFlight { get; set; }
    public Vector2 Direction { get; set; }
}
