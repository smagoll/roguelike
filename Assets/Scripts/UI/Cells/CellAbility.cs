using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

public class CellAbility : Cell
{
    private int id;
    [SerializeField]
    private TextMeshProUGUI textLevel;

    public override void Init(int id)
    {
        this.id = id;
        var selectedEquipment = DataManager.instance.abilities.Where(x => x.Id == id).FirstOrDefault();
        IsOpen = DataManager.instance.gameData.abilities.Where(x => x.id == id).Select(x => x.isOpen).FirstOrDefault();
        image.sprite = selectedEquipment.icon;
        textLevel.text = selectedEquipment.Level.ToString();
    }

    public override void SetFade(bool isOpen)
    {
        base.SetFade(isOpen);
        GetComponent<Button>().interactable = isOpen;
    }

    public void ShowWindowUpgrade()
    {
        GlobalEventManager.Start_ShowWindowUpgrade(id);
    }
}