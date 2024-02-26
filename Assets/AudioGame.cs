using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioGame : MonoBehaviour
{
    public static AudioGame instance;

    [Header("Audio Sources")]
    public AudioSource sfxSource;
    public AudioSource musicSource;
    public AudioSource moveSource;

    [Header("SFX")]
    public AudioClip hit;
    public AudioClip dropTake;

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

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }    
}
