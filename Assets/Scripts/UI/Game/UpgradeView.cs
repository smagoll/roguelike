using TMPro;
using UnityEngine;
using UnityEngine.Localization.Components;
using UnityEngine.UI;
using YG;

public class UpgradeView : MonoBehaviour
{
    [HideInInspector]
    public Upgrade upgrade;
    [SerializeField]
    private LocalizeStringEvent title;
    [SerializeField]
    private LocalizeStringEvent description;
    [SerializeField]
    private Image iconUpgrade;
    [SerializeField]
    private Image iconObjectUpgrade;


    public void SelectUpgrade()
    {
        upgrade.Action();

        if (upgrade.UpgradeType == UpgradeType.Add)
            GlobalEventManager.Start_RemoveUpgrade(upgrade);

        if(GameManager.instance.NumberStage % 5 == 0)
            YandexGame.FullscreenShow();
    }

    public void Initialize(Upgrade upgrade)
    {
        if (upgrade != null)
        {
            this.upgrade = upgrade;
            iconUpgrade.sprite = upgrade.icon;
            title.StringReference = upgrade.title;
            description.StringReference = upgrade.Description;
            
            if (upgrade.objectUpgrade != null)
            {
                iconObjectUpgrade.enabled = true;
                iconObjectUpgrade.sprite = upgrade.objectUpgrade.icon;
            }
        }
    }
}
