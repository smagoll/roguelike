using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EquipmentsUI : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabCell;
    [SerializeField]
    private EquipmentType equipmentType;
    [SerializeField]
    private Transform openAbility;
    [SerializeField]
    private Transform closeAbility;

    private List<CellEquipment> cells = new();

    private void Start()
    {
        UpdateAbilities();
    }

    public void UpdateAbilities()
    {
        var abilities = DataManager.instance.gameData.abilities.OrderBy(x => x.id).ToArray();

        foreach (var ability in abilities)
        {
            Transform transformEquipment = ability.isOpen ? openAbility : closeAbility;
            var cellObject = Instantiate(prefabCell, transformEquipment);
            var cell = cellObject.GetComponent<CellEquipment>();
            cell.InitEquipment(ability.id, equipmentType);
            cells.Add(cell);
        }
    }
}
