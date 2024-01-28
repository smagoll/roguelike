using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using DanielLochner.Assets.SimpleScrollSnap;

public class MainMenuInstaller : MonoInstaller
{
    public SimpleScrollSnap simpleScrollSnap;

    public override void InstallBindings()
    {
        Scroll();
    }

    public void Scroll()
    {
        Container.Bind<SimpleScrollSnap>().FromInstance(simpleScrollSnap).AsSingle();
    }
}
