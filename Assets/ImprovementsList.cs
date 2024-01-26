using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ImprovementsList : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabCell;
    [SerializeField]
    private Transform layout;

    private void Start()
    {
        UpdateCells();
    }

    public void UpdateCells()
    {
        var imrovements = DataManager.instance.gameData.improvements.OrderBy(x => x.id).ToArray();

        foreach (var improvement in imrovements)
        {
            var cellObject = Instantiate(prefabCell, layout);
            var cell = cellObject.GetComponent<CellImprovement>();
            cell.Init(improvement.id);
        }
    }
}
