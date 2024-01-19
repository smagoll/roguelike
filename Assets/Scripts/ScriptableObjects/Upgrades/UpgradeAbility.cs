using System.Linq;
using UnityEngine;
using Zenject;

public abstract class UpgradeAbility : UpgradeEquipment
{
    [Inject]
    private void Construct(GameData gameData)
    {
        var data = gameData.abilities.Where(x => x.id == Id).FirstOrDefault();
        Level = data.level;
        IsOpen = data.isOpen;
    }
}
