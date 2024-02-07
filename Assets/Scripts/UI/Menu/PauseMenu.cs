using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private Transform weaponMenu;
    [SerializeField]
    private Transform abilityMenu;

    [SerializeField]
    private GameObject prefabItem;

    [SerializeField]
    private Image image;


    private void Awake()
    {
        image.sprite = GameManager.player.GetComponent<Character>().hero.sprite;
    }

    public void AddItem(UpgradeEquipment upgrade)
    {
        GameObject item;
        switch (upgrade.equipmentType)
        {
            case EquipmentType.Weapon:
                item = Instantiate(prefabItem, weaponMenu);
                item.GetComponent<InfoIcon>().upgrade = upgrade;
                break;
            case EquipmentType.Ability:
                item = Instantiate(prefabItem, abilityMenu);
                item.GetComponent<InfoIcon>().upgrade = upgrade;
                break;
        }
    }

}
