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
        Container.Bind<SimpleScrollSnap>().FromInstance(simpleScrollSnap).AsSingle();
    }
}
