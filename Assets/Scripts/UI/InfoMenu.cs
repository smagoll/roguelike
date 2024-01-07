using UnityEngine;
using UnityEngine.UI;

public class InfoMenu : MonoBehaviour
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
        GlobalEventManager.AddItem.AddListener(AddItem);
        image.sprite = GameManager.player.GetComponent<Character>().hero.sprite;
    }

    public void AddItem(Upgrade upgrade)
    {
        if (upgrade.isWeapon)
        {
            var item = Instantiate(prefabItem, weaponMenu);
            item.GetComponent<InfoIcon>().upgrade = upgrade;
        }
        else
        {
            if (upgrade.isAbility)
            {
                var item = Instantiate(prefabItem, abilityMenu);
                item.GetComponent<InfoIcon>().upgrade = upgrade;
            }
        }
    }
}
