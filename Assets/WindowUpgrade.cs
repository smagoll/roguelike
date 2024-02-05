using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DanielLochner.Assets.SimpleScrollSnap;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class WindowUpgrade : MonoBehaviour
{
    [SerializeField]
    private Image image;
    [SerializeField]
    private TextMeshProUGUI nameEquipment;
    [SerializeField]
    private TextMeshProUGUI numberLevel;
    [SerializeField]
    private TextMeshProUGUI textPrice;
    [SerializeField]
    private GameObject buttonUpgrade;
    [SerializeField]
    private Transform listStats;
    [SerializeField]
    private GameObject prefabStatInfo;

    private int price;
    private int startPrice;
    [HideInInspector]
    public UpgradeEquipment equipment;
    private EquipmentData equipmentData;
    private SimpleScrollSnap scrollSnap;

    [Inject]
    private void Construct(SimpleScrollSnap scroll)
    {
        scrollSnap = scroll;
    }

    public void SetInfo(int id, EquipmentType equipmentType)
    {
        switch (equipmentType)
        {
            case EquipmentType.Weapon:
                equipment = DataManager.instance.weapons.Where(x => x.Id == id).FirstOrDefault();
                startPrice = DataManager.instance.gameData.prices.upgrade_weapons;
                break;
            case EquipmentType.Ability:
                equipment = DataManager.instance.abilities.Where(x => x.Id == id).FirstOrDefault();
                startPrice = DataManager.instance.gameData.prices.upgrade_abilities;
                break;
        }
        image.sprite = equipment.icon;
        nameEquipment.text = equipment.title;
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
        }
    }

    public void UpdateStats()
    {
        foreach(Transform child in listStats) Destroy(child.gameObject);

        foreach (var stat in equipment.stats)
        {
            var statInfo = Instantiate(prefabStatInfo, listStats);
            statInfo.GetComponent<StatInfoUI>().Initialize(equipment.Level, stat);
        }
    }

    public void IncreaseLevelAbility()
    {
        if (DataManager.instance.gameData.coins >= price)
        {
            DataManager.instance.gameData.coins -= price;
            equipment.LevelUp();
            DataManager.instance.Save();
            UpdateInfo();
            CheckPrice();
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