using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MenuEquipment : MenuElement
{
    [SerializeField]
    private GameObject prefabCell;
    [SerializeField]
    private Transform openAbility;
    [SerializeField]
    private Transform closeAbility;
    [SerializeField]
    private WindowUpgrade windowUpgrade;

    private void Start()
    {
        UpdateCells();
    }

    public void UpdateCells()
    {
        var abilities = DataManager.instance.gameData.abilities.OrderBy(x => x.id).ToArray();

        foreach (var ability in abilities)
        {
            Transform transformEquipment = ability.IsOpen ? openAbility : closeAbility;
            var cellObject = Instantiate(prefabCell, transformEquipment);
            cellObject.GetComponent<Button>().onClick.AddListener(() => AudioMenu.instance.PlayButtonDefault());
            var cell = cellObject.GetComponent<CellAbility>();
            cell.Init(ability.id);
        }
    }

    public override void UpdateView()
    {
        windowUpgrade.gameObject.SetActive(false);
    }

}
