public class HealthPoint : Drop
{
    public float countHp;

    public override void Action()
    {
        GlobalEventManager.Start_IncreaseHP(countHp);
    }
}
