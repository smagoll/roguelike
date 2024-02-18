using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "AddFireball", menuName = "Upgrades/Add/Abilities/Fireball")]
public class UpgradeAddFireball : UpgradeAbility
{
    public FireBallProjectile prefabFireball;
    public float distanceFlight;
    public float speedFlight;
    public Upgrade[] upgrades;

    public float RadiusBlast => stats.FirstOrDefault(x => x.Type == StatType.Radius).GetValue(Level);

    public override void Action()
    {
        var fireball = GameManager.player.AddComponent<FireBall>();
        fireball.Initialize(this);
    }
}
