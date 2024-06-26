using System;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;
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
    [SerializeField]
    private GameObject reviveEffect;

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

        YandexGame.NewLeaderboardScores("leaderboard", gameManager.NumberStage);
        
        DataManager.instance.Save();
    }

    public void LoadMenu()
    {
        YandexGame.FullscreenShow();
        UpdateData();
        SceneTransition.LoadScene("Menu");
    }

    public void Rewarded(int idRewarded)
    {
        if (idRewarded == 1)
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
    }

    private void ShowRewardedAd()
    {
        if (!isRevive || !isDoubleReward)
        {
            YandexGame.RewVideoShow(1);
        }
    }
    
    //public void ButtonAd()
    //{
    //    if (!isRevive)
    //    {
    //        Revive();
    //        adButtonText.StringReference = doubleAwardsStringReference;
    //        return;
    //    }
    //    
    //    if (!isDoubleReward)
    //    {
    //        DoubleReward();
    //    }
    //}

    private void Revive()
    {
        if(reviveEffect != null) Instantiate(reviveEffect, GameManager.player.transform);
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

    private void OnEnable()
    {
        YandexGame.RewardVideoEvent += Rewarded;
        AdButton.GetComponent<ClickButtonDefault>().endClick.AddListener(ShowRewardedAd);
    }
    
    private void OnDisable()
    {
        YandexGame.RewardVideoEvent -= Rewarded;
        AdButton.GetComponent<ClickButtonDefault>().endClick.RemoveListener(ShowRewardedAd);
    }
}
