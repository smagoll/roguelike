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


    public void SelectUpgrade()
    {
        upgrade.Action();

        if (upgrade.UpgradeType == UpgradeType.Add)
            GlobalEventManager.Start_RemoveUpgrade(upgrade);

        //GlobalEventManager.Start_PauseGame();
    }

    public void Initialize(Upgrade upgrade)
    {
        if (upgrade != null)
        {
            this.upgrade = upgrade;
            image.sprite = upgrade.icon;
            title.StringReference = upgrade.title;
            description.StringReference = upgrade.Description;
        }
    }
}
