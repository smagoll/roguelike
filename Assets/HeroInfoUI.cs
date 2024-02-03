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
    private Hero hero;

    void Start()
    {
        hero = DataManager.instance.heroes.FirstOrDefault(x => x.Id == DataManager.instance.gameData.equipmentSelected.id_hero);
        UpdateInfo();
    }

    private void UpdateInfo()
    {
        iconHero.sprite = hero.sprite;
        nameHero.text = hero.name;
    }
}
