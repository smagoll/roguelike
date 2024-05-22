using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class LocaleSelector : MonoBehaviour
{
    public static LocaleSelector Instance;
    private bool active;

    private void Awake() { if (Instance == null) Instance = this; }

    private void Start()
    {
        UpdateLocalization();
    }

    public void UpdateLocalization()
    {
        if (active) return;

        int id_language;
        
        switch (DataManager.instance.gameData.language)
        {
            case "ru":
                id_language = 1;
                break;
            case "en":
                id_language = 0;
                break;
            default:
                id_language = 0;
                break;
        }
        
        StartCoroutine(SetLocale(id_language));
    }

    private IEnumerator SetLocale(int localeId)
    {
        active = true;
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[localeId];
        active = false;
    }
}