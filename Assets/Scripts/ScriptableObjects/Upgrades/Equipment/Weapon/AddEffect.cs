using UnityEngine;

[CreateAssetMenu(fileName = "AddEffect", menuName = "Upgrades/EffectWeapon")]
public class AddEffect : Upgrade
{
    public Effects effect;
    public Weapons weapon;

    public override void Action()
    {
        switch (weapon)
        {
            case Weapons.Sword:
                ActivateEffect(GameManager.player.GetComponent<Sword>());
                break;
            case Weapons.Bow:
                ActivateEffect(GameManager.player.GetComponent<Bow>());
                break;
        }
    }

    private void ActivateEffect(Weapon weapon)
    {
        switch (effect)
        {
            case Effects.Bleeding:
                weapon.isBleeding = true;
                break;
        }
    }
}
