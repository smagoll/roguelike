using System.Linq;
using DG.Tweening;
using TMPro;
using UnityEngine.Localization.Components;

public class CellImprovement : Cell
{
    public int id;
    public LocalizeStringEvent title;
    public TextMeshProUGUI value;

    public override void Init(int id)
    {
        DOTween.Sequence()
            .Append(transform.DOScale(1.3f, 0.03f))
            .Append(transform.DOScale(1f, 0.03f));
        
        var selectedEquipment = DataManager.instance.improvements.Where(x => x.id == id).FirstOrDefault();
        image.sprite = selectedEquipment.icon;
        title.StringReference = selectedEquipment.title;
        value.text = selectedEquipment.Value.ToString() + "%";
        this.id = id;
        
    }
}
