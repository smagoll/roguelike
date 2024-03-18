using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsWindow : MonoBehaviour
{
    [Header("Toggles")] 
    [SerializeField]
    private Toggle music;
    [SerializeField]
    private Toggle effects;
    [Header("Icon Effects")]
    [SerializeField]
    private Image effectOn;
    [SerializeField]
    private Image effectOff;
    [Header("Icon Music")]
    [SerializeField]
    private Image musicOn;
    [SerializeField]
    private Image musicOff;

    private void Start()
    {
        music.onValueChanged.Invoke(DataManager.instance.gameData.settings.music);
        effects.onValueChanged.Invoke(DataManager.instance.gameData.settings.sounds);
        //ChangeMusic(DataManager.instance.gameData.settings.music);
        //ChangeEffects(DataManager.instance.gameData.settings.sounds);
    }

    public void ChangeMusic(bool value)
    {
        DataManager.instance.gameData.settings.music = value;
        musicOn.enabled = value;
        musicOff.enabled = !value;
        DataManager.instance.Save();
    }
    public void ChangeEffects(bool value)
    {
        DataManager.instance.gameData.settings.sounds = value;
        effectOn.enabled = value;
        effectOff.enabled = !value;
        DataManager.instance.Save();
    }
}
