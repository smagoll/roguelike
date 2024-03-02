using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;

public class LanguageChanger : MonoBehaviour
{
    private TMP_Dropdown dropdown;

    private void Awake()
    {
        dropdown = GetComponent<TMP_Dropdown>();
    }

    private void Start()
    {
        dropdown.onValueChanged.AddListener(SetLocalization);
    }

    private void SetLocalization(int id_language)
    {
        DataManager.instance.gameData.settings.id_language = id_language;
        DataManager.instance.Save();
        LocaleSelector.instance.UpdateLocalization();
    }
}
