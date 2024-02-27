public class BackgroundPause : BackgroundBack
{
    public GameUI gameUI;

    public override void Action()
    {
        gameUI.ButtonPause();
    }
}
