using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Components;
using UnityEngine.UI;

public class CellHero : Cell
{
    [SerializeField]
    private LocalizeStringEvent titleHero;
    [SerializeField]
    private TextMeshProUGUI textBlock;
    [SerializeField]
    private Image iconWeapon;
    [SerializeField]
    private Transform listStats;
    [SerializeField]
    private GameObject prefabStatInfo;

    private int id;
    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    public override void Init(int id)
    {
        var selectedEquipment = DataManager.instance.heroes.FirstOrDefault(x => x.Id == id);
        IsOpen = selectedEquipment.IsOpen;
        image.sprite = selectedEquipment.sprite;
        this.id = selectedEquipment.Id;
        button.interactable = IsOpen;
        titleHero.StringReference = selectedEquipment.title;
        iconWeapon.sprite = selectedEquipment.weapon.icon;

        var stageForOpen = DataManager.instance.gameData.heroes.FirstOrDefault(x => x.id == id).stageForOpen;
        textBlock.text = $"Необходимо пройти {stageForOpen} стадию";

        foreach (var stat in selectedEquipment.weapon.stats)
        {
            var statInfo = Instantiate(prefabStatInfo, listStats);
            statInfo.GetComponent<StatInfoUI>().Initialize(selectedEquipment.weapon.Level, stat);
        }

    }

    public void ShowWindowUpgrade()
    {
        GlobalEventManager.Start_ShowWindowUpgrade(id, EquipmentType.Weapon);
    }
}
