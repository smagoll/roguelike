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

        StartCoroutine(SetLocale(DataManager.instance.gameData.settings.id_language));
    }

    private IEnumerator SetLocale(int localeId)
    {
        active = true;
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[localeId];
        active = false;
    }
}