using System.Linq;
using UnityEngine.UI;

public class CellHero : Cell
{
    private int id;
    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    public override void Init(int id)
    {
        var selectedEquipment = DataManager.instance.heroes.FirstOrDefault(x => x.Id == id);
        IsOpen = DataManager.instance.gameData.heroes.Where(x => x.id == id).Select(x => x.isOpen).FirstOrDefault();
        image.sprite = selectedEquipment.sprite;
        this.id = selectedEquipment.Id;
        button.interactable = IsOpen;
    }

    public void ShowWindowUpgrade()
    {
        GlobalEventManager.Start_ShowWindowUpgrade(id, EquipmentType.Weapon);
    }
}
