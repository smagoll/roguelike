using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HeroesList : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabCell;
    [SerializeField]
    private Transform openCells;
    [SerializeField]
    private Transform closeCells;

    private void Start()
    {
        UpdateCells();
    }

    public void UpdateCells()
    {
        var heroes = DataManager.instance.gameData.heroes.OrderBy(x => x.id).ToArray();

        foreach (var hero in heroes)
        {
            Transform transformEquipment = hero.isOpen ? openCells : closeCells;
            var cellObject = Instantiate(prefabCell, transformEquipment);
            var cell = cellObject.GetComponent<Cell>();
            cell.Init(hero.id);
        }
    }
}
