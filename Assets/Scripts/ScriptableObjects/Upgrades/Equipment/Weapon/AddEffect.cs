using UnityEngine;

[CreateAssetMenu(fileName = "AddEffect", menuName = "Upgrades/EffectWeapon")]
public class AddEffect : Upgrade
{
    public Effect effect;
    public WeaponEnum weapon;

    public override void Action()
    {
        switch (weapon)
        {
            case WeaponEnum.Sword:
                ActivateEffect(GameManager.player.GetComponent<Sword>());
                break;
            case WeaponEnum.Bow:
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
