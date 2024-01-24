using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class CellEquipment : MonoBehaviour
{
    [SerializeField]
    private Image image;
    [SerializeField]
    private GameObject fade;

    private bool isOpen = false;

    public bool IsOpen
    {
        get => isOpen;
        set
        {
            isOpen = value;
            SetFade(isOpen);
        }
    }

    private UpgradeEquipment[] equipments;

    public UpgradeEquipment selectedEquipment;

    [Inject]
    private void Construct(UpgradeEquipment[] equipments)
    {
        this.equipments = equipments;
    }

    public void InitEquipment(int id, EquipmentType equipmentType)
    {
        switch (equipmentType)
        {
            case EquipmentType.Weapon:
                selectedEquipment = DataManager.instance.weapons.Where(x => x.Id == id).FirstOrDefault();
                IsOpen = DataManager.instance.gameData.weapons.Where(x => x.id == id).Select(x => x.isOpen).FirstOrDefault();
                break;
            case EquipmentType.Ability:
                selectedEquipment = DataManager.instance.abilities.Where(x => x.Id == id).FirstOrDefault();
                IsOpen = DataManager.instance.gameData.abilities.Where(x => x.id == id).Select(x => x.isOpen).FirstOrDefault();
                break;
        }

        image.sprite = selectedEquipment.icon;
    }

    private void SetFade(bool isOpen)
    {
        fade.SetActive(!isOpen);
    }
}
