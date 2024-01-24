using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EquipmentInstaller : MonoInstaller
{
    public Hero[] heroes;

    public override void InstallBindings()
    {
        Container.Bind<Hero[]>().FromInstance(heroes).AsSingle();
    }
}
