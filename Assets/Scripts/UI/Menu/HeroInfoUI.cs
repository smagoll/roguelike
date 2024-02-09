using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HeroInfoUI : MonoBehaviour
{
    [SerializeField]
    private Image iconHero;
    [SerializeField]
    private Image iconWeapon;
    [SerializeField]
    private TextMeshProUGUI nameHero;
    [SerializeField]
    private GameObject prefabStatInfo;
    [SerializeField]
    private Transform listWeaponsStats;
    [SerializeField]
    private WindowUpgrade windowUpgrade;

    private Hero hero;

    void Start()
    {
        UpdateInfo();
    }

    public void UpdateInfo()
    {
        foreach (Transform child in listWeaponsStats) Destroy(child.gameObject);

        var idHero = DataManager.instance.gameData.equipmentSelected.id_hero;
        hero = DataManager.instance.heroes.FirstOrDefault(x => x.Id == idHero);
        iconHero.sprite = hero.sprite;
        iconWeapon.sprite = hero.weapon.icon;
        nameHero.text = hero.title;

        foreach (var stat in hero.weapon.stats)
        {
            var statInfo = Instantiate(prefabStatInfo, listWeaponsStats);
            statInfo.GetComponent<StatInfoUI>().Initialize(hero.weapon.Level, stat);
        }

    }

    public void SelectHero()
    {
        DataManager.instance.gameData.equipmentSelected.id_hero = windowUpgrade.equipment.Id;
        DataManager.instance.Save();
        UpdateInfo();
    }
}
