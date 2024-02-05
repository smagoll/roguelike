using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameWindow : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textCoin;
    [SerializeField]
    private GameManager gameManager;

    private void Awake()
    {
        GlobalEventManager.EndGame.AddListener(UpdateTextCoin);
    }

    public void UpdateTextCoin()
    {
        textCoin.text = gameManager.Coin.ToString();
    }

    public void LoadMenu()
    {
        DataManager.instance.gameData.coins += gameManager.Coin;
        DataManager.instance.Save();
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }
}
