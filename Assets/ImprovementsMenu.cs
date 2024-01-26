using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ImprovementsMenu : MenuElement
{
    private int price;
    [SerializeField]
    private GameObject prefabCell;
    [SerializeField]
    private Transform layout;
    [SerializeField]
    private TextMeshProUGUI value;
    [SerializeField]
    private GameObject buttonBuy;

    private bool isEnable = false;

    public bool IsEnable
    {
        get => isEnable;
        set
        {
            isEnable = value;
            buttonBuy.GetComponent<Button>().interactable = isEnable;
        }
    }

    private void Start()
    {
        price = DataManager.instance.gameData.prices.improvement;
        value.text = price.ToString();
        CheckOpportunityBuy();
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

    public void BuyImprovement()
    {
        if (IsEnable)
        {
            Debug.Log("buy");
        }
    }

    public void CheckOpportunityBuy()
    {
        IsEnable = DataManager.instance.gameData.coins >= price;
    }

    public override void UpdateView()
    {
        CheckOpportunityBuy();
    }
}
