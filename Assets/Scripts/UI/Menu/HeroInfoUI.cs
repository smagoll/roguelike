using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Localization.Components;
using UnityEngine.UI;

public class HeroInfoUI : MonoBehaviour
{
    [SerializeField]
    private Image iconHero;
    [SerializeField]
    private Image iconWeapon;
    [SerializeField]
    private LocalizeStringEvent nameHero;
    [SerializeField]
    private StatInfoUI prefabStatInfo;
    [SerializeField]
    private Transform listWeaponsStats;
    [SerializeField]
    private WindowUpgrade windowUpgrade;

    private Hero hero;
    private List<StatInfoUI> stats;
    private UIAnimation animation;

    private void Awake()
    {
        animation = GetComponent<UIAnimation>();
    }

    private void Start()
    {
        UpdateInfo();
    }

    public void UpdateInfo()
    {
        foreach (Transform child in listWeaponsStats) Destroy(child.gameObject);

        var idHero = DataManager.instance.gameData.equipmentSelected.id_hero;
        hero = DataManager.instance.heroes.FirstOrDefault(x => x.Id == idHero);
        if (hero != null)
        {
            iconHero.sprite = hero.sprite;
            iconWeapon.sprite = hero.weapon.icon;
            nameHero.StringReference = hero.title;
        }
        CreateStats();
    }

    private void CreateStats()
    {
        stats = new List<StatInfoUI>();
        foreach (var stat in hero.weapon.stats)
        {
            var statInfo = Instantiate(prefabStatInfo, listWeaponsStats);
            stats.Add(statInfo);
            statInfo.Initialize(hero.weapon.Level, stat);
        }
    }

    public void UpdateStats()
    {
        foreach (var stat in stats)
        {
            stat.UpdateStat(hero.weapon.Level); 
        }
        
    }

    public void SelectHero()
    {
        DataManager.instance.gameData.equipmentSelected.id_hero = windowUpgrade.equipment.Id;
        DataManager.instance.Save();
        animation.AnimationIn();
        windowUpgrade.gameObject.GetComponent<UIAnimation>().AnimationOut();
        UpdateInfo();
    }
}
