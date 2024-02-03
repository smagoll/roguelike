using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WindowUpgrade : MonoBehaviour
{
    [SerializeField]
    private Image image;
    [SerializeField]
    private TextMeshProUGUI nameAbility;
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
    private UpgradeAbility ability;
    private EquipmentData abilityData;

    private void Awake()
    {
        startPrice = DataManager.instance.gameData.prices.upgrade_abilities;
    }

    public void SetInfo(int id)
    {
        ability = DataManager.instance.abilities.Where(x => x.Id == id).FirstOrDefault();
        abilityData = DataManager.instance.gameData.abilities.Where(x => x.id == ability.Id).FirstOrDefault();
        image.sprite = ability.icon;
        nameAbility.text = ability.name;
        UpdateInfo();
    }

    public void UpdateInfo()
    {
        price = abilityData.level * startPrice;
        numberLevel.text = abilityData.level.ToString();
        textPrice.text = price.ToString();
        UpdateStats();
    }

    public void UpdateStats()
    {
        foreach(Transform child in listStats) Destroy(child.gameObject);

        foreach (var stat in ability.stats)
        {
            var statInfo = Instantiate(prefabStatInfo, listStats);
            statInfo.GetComponent<StatInfoUI>().Initialize(abilityData, stat);
        }
    }

    public void IncreaseLevelAbility()
    {
        if (DataManager.instance.gameData.coins >= price)
        {
            DataManager.instance.gameData.coins -= price;
            abilityData.level++;
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
}
