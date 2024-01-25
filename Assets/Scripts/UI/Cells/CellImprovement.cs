using System.Linq;

public class CellImprovement : Cell
{
    public override void Init(int id)
    {
        var selectedEquipment = DataManager.instance.improvements.Where(x => x.id == id).FirstOrDefault();
        image.sprite = selectedEquipment.icon;
    }
}
