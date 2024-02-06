using UnityEngine;

[CreateAssetMenu(fileName = "AddFireball", menuName = "Upgrades/Add/Abilities/Fireball")]
public class UpgradeAddFireball : UpgradeEquipment
{
    public GameObject prefabFireball;
    public float rangeBlast;
    public float distanceFlight;
    public float speedFlight;
    public Upgrade[] upgrades;

    public override void Action()
    {
        var fireball = GameManager.player.AddComponent<FireBall>();
        fireball.Initialize(this);
    }
}
