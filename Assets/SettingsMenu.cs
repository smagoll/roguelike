using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsWindow : MonoBehaviour
{
    public void ChangeMusic(bool value) => DataManager.instance.gameData.settings.music = value; 
    public void ChangeEffects(bool value) => DataManager.instance.gameData.settings.sounds = value;
}
