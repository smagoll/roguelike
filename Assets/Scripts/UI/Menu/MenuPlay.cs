using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MenuPlay : MenuElement
{
    public EquipmentSelectedData equipmentSelected;

    [SerializeField]
    private Image iconHero;
    private Hero[] heroes;

    [Inject]
    private void Construct(Hero[] heroes)
    {
        this.heroes = heroes;
    }

    private void Start()
    {
        equipmentSelected = DataManager.instance.gameData.equipmentSelected;
        UpdateHero();
    }

    public void UpdateHero()
    {
        var hero = DataManager.instance.heroes.FirstOrDefault(x => x.Id == DataManager.instance.gameData.equipmentSelected.id_hero);
        iconHero.sprite = hero.sprite;
    }

    public override void UpdateView()
    {
        UpdateHero();
    }
}
