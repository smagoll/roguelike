[System.Serializable]
public class HeroData
{
    public int id;
    public int level;
    public bool isOpen;

    public HeroData(int id, int level, bool isOpen)
    {
        this.id = id;
        this.level = level;
        this.isOpen = isOpen;
    }
}