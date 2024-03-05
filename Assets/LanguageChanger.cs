using TMPro;
using UnityEngine;

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

    private void SetLocalization(int idLanguage)
    {
        DataManager.instance.gameData.settings.id_language = idLanguage;
        DataManager.instance.Save();
        LocaleSelector.Instance.UpdateLocalization();
    }
}
