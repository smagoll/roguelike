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
        simpleScrollSnap.OnPanelCentered.AddListener(SelectButtonCentered);
    }

    public void SelectButtonCentered(int numberCentred, int numberPrevious)
    {
        if (centeredMenu == numberCentred)
        {
            return;
        }

        //simpleScrollSnap.Panels[numberPrevious].gameObject.SetActive(false);
        centeredMenu = numberCentred;
        //simpleScrollSnap.Panels[numberCentred].gameObject.SetActive(true);
        var selectedPanel = simpleScrollSnap.Panels[numberCentred].GetComponent<MenuElement>();
        //selectedPanel.EnterView();
        var button = selectedPanel.buttonSelected;
        eventSystem.SetSelectedGameObject(button);
    }
}
