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
    private TextMeshProUGUI textRecord;
    [SerializeField]
    private GameManager gameManager;

    public void UpdateTextCoin()
    {
        textCoin.text = gameManager.Coin.ToString();
        textRecord.text = gameManager.NumberStage.ToString();
    }

    private void UpdateData()
    {
        DataManager.instance.gameData.coins += gameManager.Coin;

        if (gameManager.NumberStage > DataManager.instance.gameData.record)
        {
            DataManager.instance.gameData.record = gameManager.NumberStage;
        }

        DataManager.instance.Save();
    }

    public void LoadMenu()
    {
        UpdateData();
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        SceneTransition.LoadScene("Menu");
        Time.timeScale = 1f;
    }
}
