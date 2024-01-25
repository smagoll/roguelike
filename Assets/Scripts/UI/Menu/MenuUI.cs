using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class UIManagerMenu : MonoBehaviour
{
    public TextMeshProUGUI coinText;

    private void Awake()
    {
        GlobalEventManager.UpdateCoinMenu.AddListener(UpdateCoinText);
    }

    private void Start()
    {
        UpdateCoinText(DataManager.instance.gameData.coins);
    }

    public void UpdateCoinText(int countCoins)
    {
        coinText.text = countCoins.ToString();
    }

    public void ButtonPlay()
    {
        SceneManager.LoadScene("Game");
    }
}
