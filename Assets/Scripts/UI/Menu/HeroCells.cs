using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HeroCells : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabCell;
    [SerializeField]
    private Transform openCells;
    [SerializeField]
    private Transform closeCells;

    private List<Cell> cells = new();

    private void Start()
    {
        UpdateAbilities();
    }

    public void UpdateAbilities()
    {
        var abilities = DataManager.instance.gameData.heroes.OrderBy(x => x.id).ToArray();

        foreach (var ability in abilities)
        {
            Transform transformEquipment = ability.isOpen ? openCells : closeCells;
            var cellObject = Instantiate(prefabCell, transformEquipment);
            var cell = cellObject.GetComponent<CellHero>();
            cell.Init(ability.id);
            cells.Add(cell);
        }
    }
}
