[System.Serializable]
public class HeroData
{
    public int id;
    public bool isOpen;
    public int stageForOpen;

    public HeroData(int id, bool isOpen, int stageForOpen)
    {
        this.id = id;
        this.isOpen = isOpen;
        this.stageForOpen = stageForOpen;
    }
}