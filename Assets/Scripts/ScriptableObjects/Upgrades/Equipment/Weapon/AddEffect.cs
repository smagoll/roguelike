using UnityEngine;

[CreateAssetMenu(fileName = "AddEffect", menuName = "Upgrades/EffectWeapon")]
public class AddEffect : Upgrade
{
    public Effect effect;
    public WeaponType weapon;

    public override void Action()
    {
        switch (weapon)
        {
            case WeaponType.Sword:
                ActivateEffect(GameManager.player.GetComponent<Sword>());
                break;
            case WeaponType.Bow:
                ActivateEffect(GameManager.player.GetComponent<Bow>());
                break;
        }
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
