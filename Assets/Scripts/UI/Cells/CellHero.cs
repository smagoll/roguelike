using System.Linq;

public class CellHero : Cell
{
    public override void Init(int id)
    {
        var selectedEquipment = DataManager.instance.heroes.Where(x => x.Id == id).FirstOrDefault();
        IsOpen = DataManager.instance.gameData.heroes.Where(x => x.id == id).Select(x => x.isOpen).FirstOrDefault();
        image.sprite = selectedEquipment.sprite;
    }
}
