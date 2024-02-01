using UnityEngine;

[CreateAssetMenu(fileName = "ExplosionRadius", menuName = "Upgrades/Abilities/Fireball/ExplosionRadius")]
public class UpgradeExplosionRadiusFireball : UpgradeStats
{
    public float scaleExplosionRadius;

    public override void Action()
    {
        GameManager.player.GetComponent<FireBall>().scaleExplosionRadius += scaleExplosionRadius;
    }
}