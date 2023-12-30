public class Experience : Drop
{
    public float countXp;

    public override void Action()
    {
        GlobalEventManager.Start_UpdateXp(countXp);
    }
}
