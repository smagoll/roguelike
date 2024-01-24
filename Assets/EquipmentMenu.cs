using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject weaponsEquipmentUI;
    [SerializeField]
    private GameObject abilitiesEquipmentUI;

    public void ShowWeapons()
    {
        abilitiesEquipmentUI.SetActive(false);
        weaponsEquipmentUI.SetActive(true);
    }
    
    public void ShowAbilities()
    {
        weaponsEquipmentUI.SetActive(false);
        abilitiesEquipmentUI.SetActive(true);
    }
}
