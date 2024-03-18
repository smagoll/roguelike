using UnityEngine;
using UnityEngine.Audio;

public class AudioMenu : MonoBehaviour, ISwitchAudio
{
    public enum UISound
    {
        DefaultButton,
        BuyButton,
        UpgradeButton,
        NavigationButton,
        SelectButton,
        BackgroundBack,
        SwipeEffect
    }

    public static AudioMenu instance;

    [Header("Sources")]
    [SerializeField]
    public AudioSource musicSource;
    [SerializeField]
    private AudioSource sfxSource;
    [SerializeField]
    private AudioSource uiSource;
    
    [Header("Audio Mixer")]
    [SerializeField]
    private AudioMixer audioMixer;

    private AudioMixerGroup qwe;

    [Header("AudioClips")]
    public AudioClip music;
    public AudioClip backgroundBack;
    public AudioClip buttonNavigation;
    public AudioClip buttonDefault;
    public AudioClip buttonUpgrade;
    public AudioClip buttonSelect;
    public AudioClip buttonBuy;
    public AudioClip swipeEffect;

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
            case UISound.SwipeEffect:
                uiSource.PlayOneShot(swipeEffect);
                break;
        }
    }

    public void UpdateSettings()
    {
        if (!DataManager.instance.gameData.settings.music)
            audioMixer.SetFloat("Music", -80f);
        else
            audioMixer.SetFloat("Music", -20f);
        
        if (!DataManager.instance.gameData.settings.sounds)
        {
            audioMixer.SetFloat("UI", -80f);
            audioMixer.SetFloat("SFX", -80f);
        }
        else
        {
            audioMixer.SetFloat("UI", -15f);
            audioMixer.SetFloat("SFX", -7f);
        }
    }

    public void PlayButtonDefault() => PlayUI(UISound.DefaultButton);
    public void PlayButtonBuy() => PlayUI(UISound.BuyButton);
    public void PlayButtonUpgrade() => PlayUI(UISound.UpgradeButton);
    public void PlayButtonNavigation() => PlayUI(UISound.NavigationButton);
    public void PlayButtonSelect() => PlayUI(UISound.SelectButton);
    public void PlaySwipeEffect() => PlayUI(UISound.SwipeEffect);
}

public interface ISwitchAudio
{
    public void UpdateSettings();
}
