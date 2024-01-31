using UnityEngine;

[CreateAssetMenu(fileName = "AddEffect", menuName = "Upgrades/EffectWeapon")]
public class AddEffect : Upgrade
{
    public Effect effect;
    public WeaponType weapon;

    public override UpgradeType UpgradeType => UpgradeType.Add;

    public override void Action()
    {
          ActivateEffect(GameManager.player.GetComponent<Weapon>());

    }

    private void ActivateEffect(Weapon weapon)
    {
        switch (effect)
        {
            case Effect.Bleeding:
                weapon.isBleeding = true;
                break;
        }
    }
}
