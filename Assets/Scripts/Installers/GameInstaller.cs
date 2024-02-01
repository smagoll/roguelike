using UnityEngine;
using Zenject;
using Cinemachine;

public class GameInstaller : MonoInstaller
{
    [Header("Player")]
    public Transform spawnpoint;
    public GameObject prefabPlayer;
    public CinemachineVirtualCamera cam;

    [Header("Input")]
    public Input input;
    public Transform Canvas;
    public GameObject prefabJoystick;

    public override void InstallBindings()
    {
        SetInput();
        InstallPlayer();
    }


    public  void SetInput()
    {
        switch (input)
        {
            case Input.Mobile:
                Joystick joystick = Container.InstantiatePrefabForComponent<Joystick>(prefabJoystick, Canvas);
                Container.Bind<Joystick>().FromInstance(joystick).AsSingle().NonLazy();
                break;
        }
    }

    public void InstallPlayer()
    {
        Character character = Container
            .InstantiatePrefabForComponent<Character>(prefabPlayer, spawnpoint.position, Quaternion.identity, null);

        Container.Bind<Character>().FromInstance(character).AsSingle();
        cam.Follow = character.transform;
    }
}
