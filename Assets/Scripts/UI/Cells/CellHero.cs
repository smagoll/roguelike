using System.Collections.Generic;
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
    private StatInfoUI prefabStatInfo;
    
    [SerializeField]
    private Button button;

    private List<StatInfoUI> stats;


    public override void Init(int id)
    {
        var selectedEquipment = DataManager.instance.heroes.FirstOrDefault(x => x.Id == id);
        if (selectedEquipment != null)
        {
            IsOpen = selectedEquipment.IsOpen;
            image.sprite = selectedEquipment.sprite;
            this.id = selectedEquipment.Id;
            button.interactable = IsOpen;
            titleHero.StringReference = selectedEquipment.title;
            iconWeapon.sprite = selectedEquipment.weapon.icon;

            var stageForOpen = DataManager.instance.gameData.heroes.FirstOrDefault(x => x.id == id)!.stageForOpen;
            textBlock.text = stageForOpen.ToString();
            stats = new();
            
            foreach (var stat in selectedEquipment.weapon.stats)
            {
                var statInfo = Instantiate(prefabStatInfo, listStats);
                statInfo.Initialize(selectedEquipment.weapon.Level, stat);
                stats.Add(statInfo);
            }
        }
    }

    public void ShowWindowUpgrade()
    {
        AudioMenu.instance.PlayButtonDefault();
        GlobalEventManager.Start_ShowWindowUpgrade(this, EquipmentType.Weapon);
    }

    public override void UpdateCell()
    {
        foreach(var stat in stats) stat.UpdateStat(DataManager.instance.heroes.FirstOrDefault(x => x.Id == id)!.weapon.Level);
    }
}
