using System.Linq;

public class CellHero : Cell
{
    private int id;

    public override void Init(int id)
    {
        var selectedEquipment = DataManager.instance.heroes.FirstOrDefault(x => x.Id == id);
        IsOpen = DataManager.instance.gameData.heroes.Where(x => x.id == id).Select(x => x.isOpen).FirstOrDefault();
        image.sprite = selectedEquipment.sprite;
        this.id = selectedEquipment.Id;
    }

    public void ShowWindowUpgrade()
    {
        GlobalEventManager.Start_ShowWindowUpgrade(id, EquipmentType.Weapon);
    }
}
