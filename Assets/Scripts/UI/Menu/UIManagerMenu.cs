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
    private WindowUpgrade windowUpgrade;

    private void Awake()
    {
        GlobalEventManager.UpdateCoinMenu.AddListener(UpdateCoinText);
        GlobalEventManager.ShowWindowUpgrade.AddListener(ShowWindowUpgrade);
    }

    private void Start()
    {
        UpdateCoinText();
    }

    public void UpdateCoinText()
    {
        coinText.text = DataManager.instance.gameData.coins.ToString();
    }

    public void ButtonPlay()
    {
        SceneManager.LoadScene("Game");
    }

    public void ShowWindowUpgrade(int id, EquipmentType equipmentType)
    {
        windowUpgrade.SetInfo(id, equipmentType);
        windowUpgrade.gameObject.SetActive(true);
    }
}
