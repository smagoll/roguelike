using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AbilitiesEquipmentUI : MonoBehaviour
{
    [SerializeField]
    private CellEquipment[] cells;

    private void Awake()
    {
        SetEquipment(DataManager.gameData.equipmentSelected.id_abilities.ToArray());
    }

    public void SetEquipment(int[] idEquipment)
    {
        for (int i = 0; i < idEquipment.Length; i++)
        {
            cells[i].InitEquipment(idEquipment[i], EquipmentType.Weapon);
        }

    }
}
