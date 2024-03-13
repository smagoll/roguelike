using UnityEngine;

[CreateAssetMenu(fileName = "AddEffect", menuName = "Upgrades/EffectWeapon")]
public class AddEffect : Upgrade
{
    public Stat[] stats;
    public EffectType effect;

    public override UpgradeType UpgradeType => UpgradeType.Add;

    public override void Action()
    {
          ActivateEffect(GameManager.player.GetComponent<Weapon>());
    }

    private void ActivateEffect(Weapon weapon)
    {
        switch (effect)
        {
            case EffectType.Bleeding:
                weapon.effectControllers.Add(new EffectController<Bleeding>(stats, weapon));
                break;
            case EffectType.Gravity:
                weapon.effectControllers.Add(new EffectController<Gravity>(stats, weapon));
                break;
        }
    }
}
