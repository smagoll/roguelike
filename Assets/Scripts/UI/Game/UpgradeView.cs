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
    private TextMeshProUGUI description;
    [SerializeField]
    private Image image;

    private void Start()
    {
        if (upgrade != null)
        {
            image.sprite = upgrade.icon;
            title.StringReference = upgrade.title;
            description.text = upgrade.description;
        }
    }

    public void SelectUpgrade()
    {
        upgrade.Action();

        if (upgrade.UpgradeType == UpgradeType.Add)
            GlobalEventManager.Start_RemoveUpgrade(upgrade);

        GlobalEventManager.Start_PauseGame();
    }
}
