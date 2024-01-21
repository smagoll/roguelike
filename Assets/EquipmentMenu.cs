using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentMenu : MonoBehaviour
{
    public EquipmentSelectedData equipmentSelected;

    [SerializeField]
    private Image iconHero;
    [SerializeField]
    private WeaponsEquipmentUI weaponsEquipment;
    [SerializeField]
    private AbilitiesEquipmentUI abilitiesEquipment;

    private void Awake()
    {
        equipmentSelected = DataManager.gameData.equipmentSelected;
    }
}
