using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMenu : MonoBehaviour, ISwitchAudio
{
    public enum UISound
    {
        DefaultButton,
        BuyButton,
        UpgradeButton,
        NavigationButton,
        SelectButton,
        BackgroundBack
    }

    public static AudioMenu instance;

    [Header("Sources")]
    [SerializeField]
    private AudioSource musicSource;
    [SerializeField]
    private AudioSource sfxSource;
    [SerializeField]
    private AudioSource uiSource;

    [Header("AudioClips")]
    public AudioClip music;
    public AudioClip backgroundBack;
    public AudioClip buttonNavigation;
    public AudioClip buttonDefault;
    public AudioClip buttonUpgrade;
    public AudioClip buttonSelect;
    public AudioClip buttonBuy;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    private void Start()
    {
        musicSource.clip = music;
        musicSource.Play();
        UpdateSettings();
    }
    
    public void PlayUI(UISound uiSound)
    {
        switch (uiSound)
        {
            case UISound.DefaultButton:
                uiSource.PlayOneShot(buttonDefault);
                break;            
            case UISound.BuyButton:
                uiSource.PlayOneShot(buttonBuy);
                break;            
            case UISound.UpgradeButton:
                uiSource.PlayOneShot(buttonUpgrade);
                break;
            case UISound.NavigationButton:
                uiSource.PlayOneShot(buttonNavigation);
                break;            
            case UISound.BackgroundBack:
                uiSource.PlayOneShot(backgroundBack);
                break;            
            case UISound.SelectButton:
                uiSource.PlayOneShot(buttonSelect);
                break;
        }
    }

    public void UpdateSettings()
    {
        musicSource.enabled = DataManager.instance.gameData.settings.music;
        sfxSource.enabled = DataManager.instance.gameData.settings.sounds;
        uiSource.enabled = DataManager.instance.gameData.settings.sounds;
    }

    public void PlayButtonDefault() => PlayUI(UISound.DefaultButton);
    public void PlayButtonBuy() => PlayUI(UISound.BuyButton);
    public void PlayButtonUpgrade() => PlayUI(UISound.UpgradeButton);
    public void PlayButtonNavigation() => PlayUI(UISound.NavigationButton);
    public void PlayButtonSelect() => PlayUI(UISound.SelectButton);
}

public interface ISwitchAudio
{
    public void UpdateSettings();
}
