using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

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

    [SerializeField]
    private TextMeshProUGUI hpText;
    [SerializeField]
    private TextMeshProUGUI speedText;
    [SerializeField]
    private TextMeshProUGUI evasionText;

    private Character character;

    [Inject]
    private void Construct(Character character)
    {
        this.character = character;
    }

    private void Awake()
    {
        imageHero.sprite = character.hero.sprite;
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

    private void OnEnable()
    {
        hpText.text = character.HP.ToString();
        speedText.text = character.Speed.ToString();
        evasionText.text = character.Evasion.ToString();
    }
}
