using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonAbility : MonoBehaviour, ISelectHandler
{
    public GameObject buttonUpgrade;

    public void OnSelect(BaseEventData eventData)
    {
        buttonUpgrade.SetActive(true);
    }
}
