using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameWindow : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textCoin;

    private void Awake()
    {
        GlobalEventManager.EndGame.AddListener(UpdateTextCoin);
    }

    public void UpdateTextCoin()
    {
        textCoin.text = GameManager.Coin.ToString();
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
