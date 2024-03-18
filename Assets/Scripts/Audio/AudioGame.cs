using UnityEngine;
using UnityEngine.Audio;

public class AudioGame : MonoBehaviour, ISwitchAudio
{
    public static AudioGame instance;

    [SerializeField]
    private AudioMixer audioMixer;

    [Header("Audio Sources")]
    public AudioSource sfxMainSource;
    public AudioSource sfxSmallSource;
    public AudioSource uiSource;
    public AudioSource musicSource;
    public AudioSource moveSource;

    [Header("SFX")]
    public AudioClip dropTake;
    public AudioClip playerDamage;
    public AudioClip playerMiss;
    public AudioClip fireballExplosion;
    public AudioClip stoneExplosion;
    public AudioClip lightningCharge;
    public AudioClip magneticFieldPulse;
    public AudioClip revive;
    public AudioClip evasion;

    [Header("UI")]
    public AudioClip button_click;
    public AudioClip button_upgrade;

    [Header("Loops")]
    public AudioClip music;

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

    public void PlayMainSFX(AudioClip clip)
    {
        sfxMainSource.PlayOneShot(clip);
    }   
    
    public void PlaySmallSFX(AudioClip clip)
    {
        sfxSmallSource.PlayOneShot(clip);
    }
    
    public void PlayButtonUpgrade()
    {
        uiSource.PlayOneShot(button_upgrade);
    }
    
    public void PlayButtonClick()
    {
        uiSource.PlayOneShot(button_click);
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
}
