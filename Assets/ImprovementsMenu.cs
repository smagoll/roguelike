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
    private Transform allImprovements;
    [SerializeField]
    private TextMeshProUGUI value;
    [SerializeField]
    private GameObject buttonBuy;

    private bool isEnable = false;

    private List<CellImprovement> cells = new();

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
        UpdateView();
        UpdateCells();
    }

    public void UpdateCells()
    {
        foreach (Transform child in allImprovements.transform) Destroy(child.gameObject);

        var imrovements = DataManager.instance.gameData.improvements.OrderBy(x => x.id).ToArray();

        foreach (var improvement in imrovements)
        {
            var cellObject = Instantiate(prefabCell, allImprovements);
            var cell = cellObject.GetComponent<CellImprovement>();
            cell.Init(improvement.id);
            cells.Add(cell);
        }
    }

    public void BuyImprovement()
    {
        if (IsEnable)
        {
            RandomImprovement();
            UpdateView();
        }
    }

    public void CheckOpportunityBuy()
    {
        IsEnable = DataManager.instance.gameData.coins >= price;
    }

    public override void UpdateView()
    {
        price = DataManager.instance.gameData.prices.improvement;
        value.text = price.ToString();
        CheckOpportunityBuy();
        GlobalEventManager.Start_UpdateCoinMenu();
    }

    public void RandomImprovement()
    {
        var improvements = DataManager.instance.gameData.improvements;
        var rnd = Random.Range(0, improvements.Length);
        improvements[rnd].level++;
        cells.Where(x => x.id == improvements[rnd].id).FirstOrDefault().Init(improvements[rnd].id);
        DataManager.instance.gameData.coins -= price;
        DataManager.instance.gameData.prices.improvement += 5;
        DataManager.instance.Save();
    }
}
