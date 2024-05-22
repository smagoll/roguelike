using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;

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
    [SerializeField]
    private int countUpgradeAd;
    
    private bool isEnable;

    [SerializeField]
    private float timeBetweenAppereanceCells;
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

    public void UpdateCells()
    {
        foreach (Transform child in allImprovements.transform) Destroy(child.gameObject);

        var improvements = DataManager.instance.gameData.improvements.OrderBy(x => x.id).ToArray();

        StartCoroutine(CreateCells(improvements));
    }

    private IEnumerator CreateCells(ImprovementStatData[] improvements)
    {
        cells.Clear();
        foreach (var improvement in improvements)
        {
            var cellObject = Instantiate(prefabCell, allImprovements);
            var cell = cellObject.GetComponent<CellImprovement>();
            cell.Init(improvement.id);
            cells.Add(cell);
            yield return new WaitForSeconds(timeBetweenAppereanceCells);
        }
    }

    public void BuyImprovement()
    {
        if (IsEnable)
        {
            RandomImprovement();
            UpdateInfo();
        }
    }

    public void CheckOpportunityBuy()
    {
        IsEnable = DataManager.instance.gameData.coins >= price;
    }

    public override void EnterView()
    {
        UpdateInfo();
        UpdateCells();
    }

    public override void ExitView()
    {
        
    }

    private void UpdateInfo()
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
        cells.FirstOrDefault(x => x.id == improvements[rnd].id)?.Init(improvements[rnd].id);
        DataManager.instance.gameData.coins -= price;
        DataManager.instance.gameData.prices.improvement += 5;
        DataManager.instance.Save();
    }

    public void AdImprovement(int idReward)
    {
        if (idReward != 0) return;
        for (int i = 0; i < countUpgradeAd; i++)
        {
            var improvements = DataManager.instance.gameData.improvements;
            var rnd = Random.Range(0, improvements.Length);
            improvements[rnd].level++;
            cells.FirstOrDefault(x => x.id == improvements[rnd].id)?.Init(improvements[rnd].id);
            DataManager.instance.Save();
        }
    }

    public void LaunchAdReward() => YandexGame.RewVideoShow(0);

    public override void OnEnable()
    {
        base.OnEnable();
        YandexGame.RewardVideoEvent += AdImprovement;
    }
    
    public override void OnDisable()
    {
        base.OnDisable();
        YandexGame.RewardVideoEvent -= AdImprovement;
    }
}
