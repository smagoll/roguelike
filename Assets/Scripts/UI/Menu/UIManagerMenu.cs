using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class UIManagerMenu : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    [SerializeField]
    private WindowUpgrade windowUpgradeWeapon;
    [SerializeField]
    private WindowUpgrade windowUpgradeAbility;
    [SerializeField]
    private TextMeshProUGUI textRecord;


    private void Awake()
    {
        GlobalEventManager.UpdateCoinMenu.AddListener(UpdateCoinText);
        GlobalEventManager.ShowWindowUpgrade.AddListener(ShowWindowUpgrade);
    }

    private void Start()
    {
        UpdateCoinText();
        UpdateRecord();
    }

    public void UpdateCoinText()
    {
        coinText.text = DataManager.instance.gameData.coins.ToString();
    }

    private void UpdateRecord()
    {
        textRecord.text = DataManager.instance.gameData.record.ToString();
    }

    public void ButtonPlay()
    {
        SceneManager.LoadScene("Game");
    }

    public void ShowWindowUpgrade(int id, EquipmentType equipmentType)
    {
        switch (equipmentType)
        {
            case EquipmentType.Weapon:
                windowUpgradeWeapon.SetInfo(id, equipmentType);
                windowUpgradeWeapon.gameObject.SetActive(true);
                break;
            case EquipmentType.Ability:
                windowUpgradeAbility.SetInfo(id, equipmentType);
                windowUpgradeAbility.gameObject.SetActive(true);
                break;
        }
    }
}
