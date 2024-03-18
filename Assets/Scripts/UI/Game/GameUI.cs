using System.Collections;
using DG.Tweening;
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
    private TextMeshProUGUI textNumberStage;
    [SerializeField]
    private TextMeshProUGUI textCountCoins;
    [SerializeField]
    private EndGameWindow endWindow;

    [SerializeField]
    private PauseMenu infoMenu;

    [SerializeField]
    private GameObject upgradeViewCommon;
    [SerializeField]
    private GameObject upgradeViewUncommon;
    [SerializeField]
    private GameObject upgradeViewEpic;
    [SerializeField]
    private Transform upgradesLayout;
    [SerializeField]
    private float delayAppearanceWindowUpgrade;
    
    private bool isPause;

    
    public bool IsPause
    {
        get => isPause;
        set
        {
            isPause = value;
            GameManager.joystick.gameObject.SetActive(!isPause);
            Time.timeScale = isPause ? 0 : 1;
        }
    }

    private void Awake()
    {
        GlobalEventManager.ShowUpgrades.AddListener(ShowUpgrades);
        GlobalEventManager.EndGame.AddListener(ShowEndWindow);
        GlobalEventManager.PauseGame.AddListener(ButtonPause);
        GlobalEventManager.AddItem.AddListener(infoMenu.AddItem);
        GlobalEventManager.UpdateCoinGameText.AddListener(UpdateCoin);
    }

    public void ButtonPause()
    {
        if (!isPause)
        {
            infoHero.SetActive(true);
            IsPause = true;
        }
        else
        {
            IsPause = false;
            infoHero.SetActive(false);
        }

    }

    public void ShowUpgrades(List<Upgrade> upgrades)
    {
        IsPause = true;
        selected.SetActive(true);
        GameManager.joystick.JoystickUp();

        StartCoroutine(CreateUpgradesView(upgrades));
    }

    private IEnumerator CreateUpgradesView(List<Upgrade> upgrades)
    {
        foreach (Transform upgradeView in upgradesLayout)
        {
            Destroy(upgradeView.gameObject);
        }
        var upgradesClone = new List<Upgrade>(upgrades);
        int countUpgrades = upgrades.Count >= 3 ? 3 : upgrades.Count;
        for (int i = 0; i < countUpgrades; i++)
        {
            var randomUpgrade = RandomUpgrade(ref upgradesClone);
            CreateUpgradeView(randomUpgrade);
            yield return new WaitForSecondsRealtime(delayAppearanceWindowUpgrade);
        }
    }
    
    private void CreateUpgradeView(Upgrade upgrade)
    {
        GameObject upgradeView= null;

        switch (upgrade.rare)
        {
            case RareType.Common:
                upgradeView = Instantiate(upgradeViewCommon, upgradesLayout);
                break;
            case RareType.Uncommon:
                upgradeView = Instantiate(upgradeViewUncommon, upgradesLayout);
                break;
            case RareType.Epic:
                upgradeView = Instantiate(upgradeViewEpic, upgradesLayout);
                break;
        }

        if (upgradeView != null)
        {
            upgradeView.GetComponent<UpgradeView>().Initialize(upgrade);
            upgradeView.GetComponent<ClickButtonDefault>().endClick.AddListener(HideSelected);
            upgradeView.GetComponent<Button>().onClick.AddListener(AudioGame.instance.PlayButtonUpgrade);
        }
    }
    
    public void HideSelected()
    {
        selected.SetActive(false);
        IsPause = false;
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

    private void UpdateCoin(int coins)
    {
        DOTween.Sequence().AppendCallback(() => textCountCoins.text = coins.ToString())
            .Append(textCountCoins.transform.DOScale(1.2f, 0.1f))
            .Append(textCountCoins.transform.DOScale(1f, 0.1f)).SetEase(Ease.OutBounce);
    }
}
