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
    private UpgradeEquipment[] equipments;

    public UpgradeEquipment selectedEquipment;

    [Inject]
    private void Construct(UpgradeEquipment[] equipments)
    {
        this.equipments = equipments;
    }

    public void InitEquipment(int id, EquipmentType equipmentType)
    {
        selectedEquipment = equipments.Where(x => x.Id == id && equipmentType == x.equipmentType).FirstOrDefault();
        image.sprite = selectedEquipment.icon;
    }
}
