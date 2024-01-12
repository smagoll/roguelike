using UnityEngine;
using Zenject;

public class InputInstaller : MonoInstaller
{
    public Input input;

    public Transform Canvas;
    public GameObject prefabJoystick;

    public override void InstallBindings()
    {
        switch (input)
        {
            case Input.Mobile:
                Joystick joystick = Container.InstantiatePrefabForComponent<Joystick>(prefabJoystick, Canvas);
                Container.Bind<Joystick>().FromInstance(joystick).AsSingle();
                break;
        }
    }
}