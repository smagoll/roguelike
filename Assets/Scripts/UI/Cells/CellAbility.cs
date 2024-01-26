using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class CellAbility : Cell
{
    public override void Init(int id)
    {
        var selectedEquipment = DataManager.instance.abilities.Where(x => x.Id == id).FirstOrDefault();
        IsOpen = DataManager.instance.gameData.abilities.Where(x => x.id == id).Select(x => x.isOpen).FirstOrDefault();
        image.sprite = selectedEquipment.icon;
    }
}