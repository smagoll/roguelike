using System;
using System.Collections.Generic;
using System.Linq;
using DanielLochner.Assets.SimpleScrollSnap;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Components;
using UnityEngine.UI;
using Zenject;

public class WindowUpgrade : MonoBehaviour
{
    [SerializeField]
    private Image image;
    [SerializeField]
    private LocalizeStringEvent nameEquipment;
    [SerializeField]
    private TextMeshProUGUI numberLevel;
    [SerializeField]
    private TextMeshProUGUI textPrice;
    [SerializeField]
    private GameObject buttonUpgrade;
    [SerializeField]
    private Transform listStats;
    [SerializeField]
    private StatInfoUI prefabStatInfo;    
    
    [SerializeField]
    private MenuHeroes menuHeroes;

    private int price;
    private int startPrice;
    [HideInInspector]
    public UpgradeEquipment equipment;
    private EquipmentData equipmentData;
    private SimpleScrollSnap scrollSnap;
    private Cell selectedCellHero;

    private List<StatInfoUI> stats;
    public UIAnimation animation;
    
    
    [Inject]
    private void Construct(SimpleScrollSnap scroll)
    {
        scrollSnap = scroll;
    }

    private void Awake()
    {
        animation = GetComponent<UIAnimation>();
    }

    public void SetInfo(Cell cell, EquipmentType equipmentType)
    {
        selectedCellHero = cell;
        switch (equipmentType)
        {
            case EquipmentType.Weapon:
                equipment = DataManager.instance.weapons.FirstOrDefault(x => x.Id == selectedCellHero.id);
                startPrice = DataManager.instance.gameData.prices.upgrade_weapons;
                break;
            case EquipmentType.Ability:
                equipment = DataManager.instance.abilities.FirstOrDefault(x => x.Id == selectedCellHero.id);
                startPrice = DataManager.instance.gameData.prices.upgrade_abilities;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(equipmentType), equipmentType, null);
        }

        if (equipment != null)
        {
            image.sprite = equipment.icon;
            nameEquipment.StringReference = equipment.title;
        }
        CreateStats();
        UpdateInfo();
    }

    public void UpdateInfo()
    {
        if (equipment != null)
        {
            price = equipment.Level * startPrice;
            numberLevel.text = equipment.Level.ToString();
            textPrice.text = price.ToString();
            UpdateStats();
            CheckPrice();
        }
    }

    private void CreateStats()
    {
        stats = new();
        foreach(Transform child in listStats) Destroy(child.gameObject);

        foreach (var stat in equipment.stats)
        {
            var statInfo = Instantiate(prefabStatInfo, listStats);
            statInfo.Initialize(equipment.Level, stat);
            stats.Add(statInfo);
        }
    }

    public void UpdateStats()
    {
        foreach(var stat in stats)stat.UpdateStat(equipment.Level);
    }

    public void IncreaseLevelAbility()
    {
        if (DataManager.instance.gameData.coins >= price)
        {
            DataManager.instance.gameData.coins -= price;
            equipment.LevelUp();
            DataManager.instance.Save();
            UpdateInfo();
            selectedCellHero.UpdateCell();
            GlobalEventManager.Start_UpdateCoinMenu();
        }
    }

    public void CheckPrice()
    {
        if (DataManager.instance.gameData.coins < price)
        {
            buttonUpgrade.GetComponent<Button>().interactable = false;
        }
        else
        {
            buttonUpgrade.GetComponent<Button>().interactable = true;
        }
    }
    
    private void OnEnable()
    {
        scrollSnap.UseSwipeGestures = false;
    }
    
    private void OnDisable()
    {
        scrollSnap.UseSwipeGestures = true;
    }
}