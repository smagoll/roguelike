using DanielLochner.Assets.SimpleScrollSnap;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScrollMenu : MonoBehaviour
{
    public SimpleScrollSnap simpleScrollSnap;
    public EventSystem eventSystem;

    private int centeredMenu = -1;

    private void Start()
    {
        simpleScrollSnap.OnPanelCentered.AddListener(SelectButtonCentered);
        SelectButtonCentered(simpleScrollSnap.CenteredPanel);
    }

    public void SelectButtonCentered(int numberCentred, int numberPrevious)
    {
        if (centeredMenu == numberCentred)
        {
            return;
        }
        
        centeredMenu = numberCentred;
        var selectedPanel = simpleScrollSnap.Panels[numberCentred].GetComponent<MenuElement>();
        selectedPanel.toggle.isOn = true;
    }
    
    public void SelectButtonCentered(int numberCentred)
    {
        if (centeredMenu == numberCentred)
        {
            return;
        }
        
        centeredMenu = numberCentred;
        var selectedPanel = simpleScrollSnap.Panels[numberCentred].GetComponent<MenuElement>();
        selectedPanel.toggle.isOn = true;
    }
}
