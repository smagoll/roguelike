using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "ExplosionRadius", menuName = "Upgrades/Abilities/Fireball/ExplosionRadius")]
public class UpgradeExplosionRadiusFireball : UpgradeStats
{
    public float scaleExplosionRadius;

    public override LocalizedString Description
    {
        get
        {
            description.Arguments = new object[] { scaleExplosionRadius };
            description.RefreshString();
            return description;
        }
    }

    public override void Action()
    {
        GameManager.player.GetComponent<FireBall>().scaleExplosionRadius += scaleExplosionRadius;
    }
}