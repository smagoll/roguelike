using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField]
    private GameObject selected;
    [SerializeField]
    private GameObject infoHero;
    [SerializeField]
    private TextMeshProUGUI textXp;
    [SerializeField]
    private TextMeshProUGUI textNumberStage;

    [SerializeField]
    private InfoMenu infoMenu;

    [SerializeField]
    private GameObject upgradeViewPrefab;
    [SerializeField]
    private Transform upgradesLayout;

    private static bool isPause = false;

    public static bool IsPause
    {
        get => isPause;
        set
        {
            isPause = value;
            GameManager.joystick.gameObject.SetActive(!isPause);
        }
    }

    private void Awake()
    {
        GlobalEventManager.ShowUpgrades.AddListener(ShowUpgrades);
        GlobalEventManager.AddItem.AddListener(infoMenu.AddItem);
    }

    public void ButtonPause()
    {
        if (!isPause)
        {
            infoHero.SetActive(true);
            Time.timeScale = 0;
            IsPause = true;
        }
        else
        {
            IsPause = false;
            infoHero.SetActive(false);
            Time.timeScale = 1;
        }

    }

    public void ShowUpgrades(List<Upgrade> upgrades)
    {
        IsPause = true;
        selected.SetActive(true);
        Time.timeScale = 0f;

        var upgradesClone = new List<Upgrade>(upgrades);
        int countUpgrades = upgrades.Count >= 3 ? 3 : upgrades.Count;
        for (int i = 0; i < countUpgrades; i++)
        {
            var randomUpgrade = RandomUpgrade(ref upgradesClone);
            CreateUpgradeView(randomUpgrade);
        }
    }

    private void CreateUpgradeView(Upgrade upgrade)
    {
        var upgradeView = Instantiate(upgradeViewPrefab, upgradesLayout);
        upgradeView.GetComponent<UpgradeView>().upgrade = upgrade;
        upgradeView.GetComponent<Button>().onClick.AddListener(HideSelected);
    }
    
    public void HideSelected()
    {
        selected.SetActive(false);
        Time.timeScale = 1f;

        foreach (Transform upgradeView in upgradesLayout)
        {
            Destroy(upgradeView.gameObject);
        }
    }

    public void ButtonOK()
    {
        HideSelected();
    }

    public Upgrade RandomUpgrade(ref List<Upgrade> upgrades)
    {
        int maxRange = upgrades.Sum(x => x.chance);
        var random = Random.Range(0, maxRange);
        foreach (var upgrade in upgrades)
        {
            if (random > upgrade.chance)
            {
                random -= upgrade.chance;
            }
            else
            {
                upgrades.Remove(upgrade);
                return upgrade;
            }
        }
        return null;
    }

    public void ShowEndWindow()
    {

    }
}
