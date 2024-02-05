using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MenuHeroes : MenuElement
{
    [SerializeField]
    private GameObject prefabCell;
    [SerializeField]
    private Transform openCells;
    [SerializeField]
    private Transform closeCells;
    [SerializeField]
    private HeroInfoUI heroInfoUI;

    private void Start()
    {
        UpdateCells();
    }

    public void UpdateCells()
    {
        if (openCells.transform.childCount > 0)
        {
            foreach (Transform child in openCells.transform) Destroy(child.gameObject);
        }

        var heroes = DataManager.instance.gameData.heroes.OrderBy(x => x.id).ToArray();

        foreach (var hero in heroes)
        {
            Transform transformEquipment = hero.isOpen ? openCells : closeCells;
            var cellObject = Instantiate(prefabCell, transformEquipment);
            var cell = cellObject.GetComponent<CellHero>();
            cell.Init(hero.id);
        }
    }

    public override void UpdateView()
    {
        UpdateCells();
        heroInfoUI.UpdateInfo();
    }
}
