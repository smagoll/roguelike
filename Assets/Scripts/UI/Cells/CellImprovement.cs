using System.Linq;
using DG.Tweening;
using TMPro;
using UnityEngine.Localization.Components;

public class CellImprovement : Cell
{
    public LocalizeStringEvent title;
    public TextMeshProUGUI value;

    public override void Init(int id)
    {
        DOTween.Sequence()
            .Append(transform.DOScale(1.3f, 0.2f))
            .Append(transform.DOScale(1f, 0.2f)).SetEase(Ease.OutBounce);
        
        var selectedEquipment = DataManager.instance.improvements.FirstOrDefault(x => x.id == id);
        if (selectedEquipment != null)
        {
            image.sprite = selectedEquipment.icon;
            title.StringReference = selectedEquipment.title;
            value.text = selectedEquipment.Value + "%";
        }

        this.id = id;
        
    }

    public override void UpdateCell()
    {
        
    }
}
