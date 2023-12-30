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
    private GameObject damageHurtPrefab;
    [SerializeField]
    private TextMeshProUGUI textXp;
    [SerializeField]
    private TextMeshProUGUI textNumberStage;

    [SerializeField]
    private GameObject upgradeViewPrefab;
    [SerializeField]
    private Transform upgradesLayout;

    private void Awake()
    {
        GlobalEventManager.ShowUpgrades.AddListener(ShowUpgrades);
        GlobalEventManager.UpdateXpText.AddListener(UpdateXpText);
        GlobalEventManager.UpdateStageText.AddListener(UpdateStageText);
        GlobalEventManager.CreateDamageHurt.AddListener(CreateDamageHurt);
    }

    public void ShowUpgrades(List<Upgrade> upgrades)
    {
        selected.SetActive(true);
        Time.timeScale = 0f;

        var countUpgrades = 3;
        var upgradesClone = new List<Upgrade>(upgrades);
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

    private void UpdateXpText(float xpCollect, float xpForCurrentStage)
    {
        textXp.text = $"{xpCollect}/{xpForCurrentStage}";
    }    
    
    private void UpdateStageText(int numberStage)
    {
        textNumberStage.text = $"Stage {numberStage}";
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

    private void CreateDamageHurt(Vector3 position, float damage)
    {
        var damageHurt = Instantiate(damageHurtPrefab, position, Quaternion.identity);
        damageHurt.GetComponent<DamageHurt>().damage = damage;
    }
}
