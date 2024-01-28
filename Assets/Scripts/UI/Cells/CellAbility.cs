using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

public class CellAbility : Cell, ISelectHandler, IDeselectHandler
{
    [SerializeField]
    private TextMeshProUGUI textLevel;
    [SerializeField]
    private GameObject buttonUpgrade;

    public override void Init(int id)
    {
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

    public void qwe()
    {
        Debug.Log("qwe");
    }

    public void OnSelect(BaseEventData eventData)
    {
        buttonUpgrade.SetActive(true);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        buttonUpgrade.SetActive(false);
    }
}