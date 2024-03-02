using System.Linq;
using TMPro;
using UnityEngine.Localization.Components;

public class CellImprovement : Cell
{
    public int id;
    public LocalizeStringEvent title;
    public TextMeshProUGUI value;

    public override void Init(int id)
    {
        var selectedEquipment = DataManager.instance.improvements.Where(x => x.id == id).FirstOrDefault();
        image.sprite = selectedEquipment.icon;
        title.StringReference = selectedEquipment.title;
        value.text = selectedEquipment.Value.ToString() + "%";
        this.id = id;
    }
}
