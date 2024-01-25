using System.Collections;
using System.Collections.Generic;
using DanielLochner.Assets.SimpleScrollSnap;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScrollMenu : MonoBehaviour
{
    public SimpleScrollSnap simpleScrollSnap;
    public EventSystem eventSystem;

    private int centeredMenu;

    private void Start()
    {
        simpleScrollSnap.OnPanelCentered.AddListener(SelectButton);
    }

    public void SelectButton(int numberCentred, int numberPrevious)
    {
        if (centeredMenu == numberCentred)
        {
            return;
        }
        else
        {
            centeredMenu = numberCentred;
        }

        var panel = simpleScrollSnap.Panels[numberCentred];
        var button = panel.GetComponent<ElementMenu>().buttonSelected;
        eventSystem.SetSelectedGameObject(button);
    }



    
}
