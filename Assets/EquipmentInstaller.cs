using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EquipmentInstaller : MonoInstaller
{
    public UpgradeEquipment[] equipments;

    public override void InstallBindings()
    {
        Container.Bind<UpgradeEquipment[]>().FromInstance(equipments).AsSingle();
    }
}
