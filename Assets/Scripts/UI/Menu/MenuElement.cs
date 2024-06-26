using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DanielLochner.Assets.SimpleScrollSnap;
using UnityEngine.UI;
using Zenject;

public abstract class MenuElement : MonoBehaviour
{
    [Header("Navigation")]
    private SimpleScrollSnap simpleScrollSnap;
    public int numberPanel;
    public Toggle toggle;

    [Inject]
    public void Construct(SimpleScrollSnap simpleScrollSnap)
    {
        this.simpleScrollSnap = simpleScrollSnap;
    }

    public void Select(bool isSelect)
    {
        if (isSelect) simpleScrollSnap.GoToPanel(numberPanel);
    }

    public abstract void EnterView();
    public abstract void ExitView();

    public virtual void OnEnable() => EnterView();
    public virtual void OnDisable() => ExitView();
}
