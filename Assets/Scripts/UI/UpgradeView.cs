using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeView : MonoBehaviour
{
    public Upgrade upgrade;
    [SerializeField]
    private TextMeshProUGUI title;
    [SerializeField]
    private TextMeshProUGUI level;
    [SerializeField]
    private TextMeshProUGUI description;

    private void Start()
    {
        if (upgrade != null)
        {
            title.text = upgrade.title;
            description.text = upgrade.description;
        }
    }

    public void SelectUpgrade()
    {
        upgrade.Action();
    }
}
