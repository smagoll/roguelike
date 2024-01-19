using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class DataInstaller : MonoInstaller
{
    public DataManager dataManager;

    public override void InstallBindings()
    {
        Data();
    }

    public void Data()
    {
        var gameData = dataManager.gameData;
        Container.Bind<GameData>().FromInstance(gameData).AsSingle();
    }
}
