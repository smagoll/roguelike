using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ImprovementList : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabCell;
    [SerializeField]
    private Transform openAbility;
    [SerializeField]
    private Transform closeAbility;

    private void Start()
    {
        UpdateCells();
    }

    public void UpdateCells()
    {
        var abilities = DataManager.instance.gameData.improvements.OrderBy(x => x.id).ToArray();

        foreach (var ability in abilities)
        {
            var cellObject = Instantiate(prefabCell, openAbility);
            var cell = cellObject.GetComponent<CellImprovement>();
            cell.Init(ability.id);
        }
    }
}
