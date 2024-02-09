using System.Linq;

public class EffectController<T> : IEffectController where T: Effect
{
    private Stat[] stats;
    private Weapon weapon;

    public EffectController(Stat[] stats, Weapon weapon)
    {
        this.stats = stats;
        this.weapon = weapon;
    }

    public void AddEffect(Enemy enemy)
    {
        var effect = enemy.GetComponent<T>();

        if (effect == null)
        {
            effect = enemy.gameObject.AddComponent<T>();
            effect.stats = stats;
            effect.weapon = weapon;
        }
    }
}
