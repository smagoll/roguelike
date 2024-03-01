using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [Header("Hero stats")]
    [SerializeField]
    private Transform weaponMenu;
    [SerializeField]
    private Transform abilityMenu;
    [SerializeField]
    private Image imageHero;
    [SerializeField]
    private GameObject prefabEquipment;
    [SerializeField]
    private GameObject confirmation;

    private void Awake()
    {
        imageHero.sprite = GameManager.player.GetComponent<Character>().hero.sprite;
    }

    public void AddItem(UpgradeEquipment upgrade)
    {
        GameObject item;
        switch (upgrade.equipmentType)
        {
            case EquipmentType.Weapon:
                item = Instantiate(prefabEquipment, weaponMenu);
                item.GetComponent<InfoIcon>().upgrade = upgrade;
                break;
            case EquipmentType.Ability:
                item = Instantiate(prefabEquipment, abilityMenu);
                item.GetComponent<InfoIcon>().upgrade = upgrade;
                break;
        }
    }

    public void ShowConfirmation() => confirmation.SetActive(true);
}
