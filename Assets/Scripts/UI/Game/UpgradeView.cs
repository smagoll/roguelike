using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeView : MonoBehaviour
{
    [HideInInspector]
    public Upgrade upgrade;
    [SerializeField]
    private TextMeshProUGUI title;
    [SerializeField]
    private TextMeshProUGUI description;
    [SerializeField]
    private Image image;

    private void Start()
    {
        if (upgrade != null)
        {
            image.sprite = upgrade.icon;
            title.text = upgrade.title;
            description.text = upgrade.description;
        }
    }

    public void SelectUpgrade()
    {
        upgrade.Action();

        if (upgrade.UpgradeType == UpgradeType.Add)
            GlobalEventManager.Start_RemoveUpgrade(upgrade);

        GameUI.IsPause = false;
    }
}
