using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DanielLochner.Assets.SimpleScrollSnap;
using UnityEngine.UI;
using Zenject;

public class ElementMenu : MonoBehaviour
{
    public SimpleScrollSnap simpleScrollSnap;
    public int numberPanel;
    public GameObject buttonSelected;

    private void Start()
    {
        buttonSelected.GetComponent<Button>().onClick.AddListener(Select);
    }

    [Inject]
    public void Construct(SimpleScrollSnap simpleScrollSnap)
    {
        this.simpleScrollSnap = simpleScrollSnap;
    }

    private void Select()
    {
        simpleScrollSnap.GoToPanel(numberPanel);
    }
}
