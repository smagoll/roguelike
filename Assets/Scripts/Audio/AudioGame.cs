using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioGame : MonoBehaviour, ISwitchAudio
{
    public static AudioGame instance;

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
        var isSound = DataManager.instance.gameData.settings.sounds;
        var isMusic = DataManager.instance.gameData.settings.music;
        sfxMainSource.enabled = isSound;
        sfxSmallSource.enabled = isSound;
        uiSource.enabled = isSound;
        musicSource.enabled = isMusic;
        moveSource.enabled = isSound;
    }
}
