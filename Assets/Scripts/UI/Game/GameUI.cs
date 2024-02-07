using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField]
    private GameObject selected;
    [SerializeField]
    private GameObject infoHero;
    [SerializeField]
    private TextMeshProUGUI textNumberStage;
    [SerializeField]
    private TextMeshProUGUI textCountCoins;
    [SerializeField]
    private EndGameWindow endWindow;

    [SerializeField]
    private PauseMenu infoMenu;

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
        GlobalEventManager.EndGame.AddListener(ShowEndWindow);
        GlobalEventManager.AddItem.AddListener(infoMenu.AddItem);
        GlobalEventManager.UpdateCoinGameText.AddListener((int coins) => textCountCoins.text = coins.ToString());
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
        GameManager.joystick.JoystickUp();

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
        var rare = GameCalculator.GetRandomRareUpgrade();
        var randomUpgrades = upgrades.Where(x => x.rare == rare).ToArray();

        var rnd = Random.Range(0, randomUpgrades.Length);
        var upgrade = randomUpgrades[rnd];
        upgrades.Remove(upgrade);
        return upgrade;
    }

    public void ShowEndWindow()
    {
        Time.timeScale = 0f;
        endWindow.UpdateTextCoin();
        endWindow.gameObject.SetActive(true);
    }
}
