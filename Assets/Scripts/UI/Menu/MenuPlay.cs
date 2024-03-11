using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MenuPlay : MenuElement
{
    [SerializeField]
    private Image iconHero;

    private void Start()
    {
        EnterView();
    }

    private void UpdateHero()
    {
        var hero = DataManager.instance.heroes.FirstOrDefault(x => x.Id == DataManager.instance.gameData.equipmentSelected.id_hero);
        if (hero != null) iconHero.sprite = hero.sprite;
    }

    public override void EnterView()
    {
        UpdateHero();
    }

    public override void ExitView()
    {
        
    }
}
