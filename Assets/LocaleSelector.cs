using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class LocaleSelector : MonoBehaviour
{
    public static LocaleSelector instance;
    private bool active = false;

    private void Awake() { if (instance == null) instance = this; }

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
