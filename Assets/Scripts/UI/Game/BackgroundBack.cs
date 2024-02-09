using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BackgroundBack : MonoBehaviour, IPointerDownHandler
{
    [SerializeField]
    private GameObject window;

    public void OnPointerDown(PointerEventData eventData)
    {
        window.SetActive(false);
    }
}
