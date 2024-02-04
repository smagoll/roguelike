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
    private TextMeshProUGUI nameHero;
    [SerializeField]
    private GameObject prefabStatInfo;
    [SerializeField]
    private Transform listHeroStats;
    [SerializeField]
    private Transform listWeaponsStats;

    private Hero hero;

    void Start()
    {
        UpdateInfo();
    }

    private void UpdateInfo()
    {
        var idHero = DataManager.instance.gameData.equipmentSelected.id_hero;
        hero = DataManager.instance.heroes.FirstOrDefault(x => x.Id == idHero);
        iconHero.sprite = hero.sprite;
        nameHero.text = hero.name;

        foreach (var stat in hero.weapon.stats)
        {
            var statInfo = Instantiate(prefabStatInfo, listWeaponsStats);
            statInfo.GetComponent<StatInfoUI>().Initialize(hero.weapon.Level, stat);
        }

    }
}
