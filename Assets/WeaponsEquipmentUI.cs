using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsEquipmentUI : MonoBehaviour
{
    [SerializeField]
    private CellEquipment[] cells;

    private void Awake()
    {
        SetEquipments(DataManager.gameData.equipmentSelected.id_weapons.ToArray());
    }

    public void SetEquipments(int[] idEquipment)
    {
        for (int i = 0; i < idEquipment.Length; i++)
        {
            cells[i].InitEquipment(idEquipment[i], EquipmentType.Weapon);
        }
    }
}
