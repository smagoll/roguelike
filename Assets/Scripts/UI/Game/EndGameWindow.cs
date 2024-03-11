using System;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

public class EndGameWindow : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textCoin;
    [SerializeField]
    private TextMeshProUGUI textRecord;
    [SerializeField]
    private GameManager gameManager;
    [SerializeField]
    private Button AdButton;
    [SerializeField]
    private LocalizeStringEvent adButtonText;
    [SerializeField]
    private LocalizedString doubleAwardsStringReference;

    public bool isRevive;
    public bool isDoubleReward;

    private Character character;

    [Inject]
    private void Construct(Character character)
    {
        this.character = character;
    }    
    
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
        //SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        SceneTransition.LoadScene("Menu");
        Time.timeScale = 1f;
    }

    public void ButtonAd()
    {
        if (!isRevive)
        {
            Revive();
            adButtonText.StringReference = doubleAwardsStringReference;
            return;
        }
        
        if (!isDoubleReward)
        {
            DoubleReward();
        }
    }

    private void Revive()
    {
        Time.timeScale = 1f;
        UpdateTextCoin();
        character.HP = character.MaxHP / 2;
        isRevive = true;
        AudioGame.instance.PlayMainSFX(AudioGame.instance.revive);
        
        gameObject.SetActive(false);
    }

    private void DoubleReward()
    {
        gameManager.Coin *= 2;
        UpdateTextCoin();
        isDoubleReward = true;

        AdButton.interactable = false;
    }
}
