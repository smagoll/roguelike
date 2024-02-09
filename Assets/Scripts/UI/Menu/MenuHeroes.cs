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
        ClearCells();

        foreach (var hero in DataManager.instance.gameData.heroes.OrderBy(x => x.id))
        {
            Transform transformEquipment = hero.stageForOpen <= DataManager.instance.gameData.record ? openCells : closeCells;
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

    private void ClearCells()
    {
        if (openCells.transform.childCount > 0)
        {
            foreach (Transform child in openCells.transform) Destroy(child.gameObject);
        }

        if (closeCells.transform.childCount > 0)
        {
            foreach (Transform child in closeCells.transform) Destroy(child.gameObject);
        }
    }
}
