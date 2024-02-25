using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioUI : MonoBehaviour
{
    public enum SFX
    {
        click
    }

    private AudioUI instance;

    [SerializeField]
    private AudioSource musicSource;
    [SerializeField]
    private AudioSource sfxSource;

    public AudioClip background;
    public AudioClip click;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
}

[System.Serializable]
public class SoundAudioClip
{
    public AudioUI.SFX sfx;
    public AudioClip audioClip;
}
