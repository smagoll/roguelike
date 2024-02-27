using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioGame : MonoBehaviour
{
    public static AudioGame instance;

    [Header("Audio Sources")]
    public AudioSource sfxMainSource;
    public AudioSource sfxSmallSource;
    public AudioSource musicSource;
    public AudioSource moveSource;

    [Header("SFX")]
    public AudioClip dropTake;
    public AudioClip playerDamage;
    public AudioClip playerMiss;
    public AudioClip fireballExplosion;
    public AudioClip lightningCharge;
    public AudioClip magneticFieldPulse;

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
}
