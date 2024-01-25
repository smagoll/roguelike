using UnityEngine;
using UnityEngine.UI;

public class InfoIcon : MonoBehaviour
{
    public Upgrade upgrade;

    [SerializeField]
    private Image icon;

    private void Start()
    {
        icon.sprite = upgrade.icon;
    }
}
