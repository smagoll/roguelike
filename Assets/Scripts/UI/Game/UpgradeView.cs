using TMPro;
using UnityEngine;
using UnityEngine.Localization.Components;
using UnityEngine.UI;

public class UpgradeView : MonoBehaviour
{
    [HideInInspector]
    public Upgrade upgrade;
    [SerializeField]
    private LocalizeStringEvent title;
    [SerializeField]
    private LocalizeStringEvent description;
    [SerializeField]
    private Image image;
    [SerializeField]
    private Image background;

    [Header("Backgrounds")]
    [SerializeField]
    private Sprite backgroundCommon;
    [SerializeField]
    private Sprite backgroundUncommon;
    [SerializeField]
    private Sprite backgroundEpic;


    private void Start()
    {
        if (upgrade != null)
        {
            image.sprite = upgrade.icon;
            title.StringReference = upgrade.title;
            description.StringReference = upgrade.Description;
            SetBackground(upgrade.rare);
        }
    }

    public void SelectUpgrade()
    {
        upgrade.Action();

        if (upgrade.UpgradeType == UpgradeType.Add)
            GlobalEventManager.Start_RemoveUpgrade(upgrade);

        GlobalEventManager.Start_PauseGame();
    }

    private void SetBackground(RareType rare)
    {
        switch (rare)
        {
            case RareType.Common:
                background.sprite = backgroundCommon;
                break;
            case RareType.Uncommon:
                background.sprite = backgroundUncommon;
                break;
            case RareType.Epic:
                background.sprite = backgroundEpic;
                break;
        }
    }
}
