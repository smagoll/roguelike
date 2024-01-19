using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UIManagerMenu : MonoBehaviour
{
    public TextMeshProUGUI coinText;

    private void Awake()
    {
        GlobalEventManager.UpdateCoinMenu.AddListener(UpdateCoinText);
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
