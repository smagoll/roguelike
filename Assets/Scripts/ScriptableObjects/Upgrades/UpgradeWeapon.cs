using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Zenject;

public abstract class UpgradeWeapon : UpgradeEquipment
{
    public GameData gameData;

    [Inject]
    private void Construct(GameData data)
    {
        gameData = data;
    }
}