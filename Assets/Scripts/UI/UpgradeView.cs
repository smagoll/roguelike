using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeView : MonoBehaviour
{
    public Upgrade upgrade;
    [SerializeField]
    private TextMeshProUGUI title;
    [SerializeField]
    private TextMeshProUGUI level;
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
            level.text = upgrade.level.ToString();
            description.text = upgrade.description;
        }
    }

    public void SelectUpgrade()
    {
        upgrade.Action();
    }
}
