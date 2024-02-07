using System.Linq;
using TMPro;

public class CellImprovement : Cell
{
    public int id;
    public TextMeshProUGUI title;
    public TextMeshProUGUI value;

    public override void Init(int id)
    {
        var selectedEquipment = DataManager.instance.improvements.Where(x => x.id == id).FirstOrDefault();
        image.sprite = selectedEquipment.icon;
        title.text = selectedEquipment.title;
        value.text = selectedEquipment.Value.ToString() + "%";
        this.id = id;
    }
}
