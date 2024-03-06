using System.Collections;
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

    public void UpdateCells()
    {
        var abilities = DataManager.instance.gameData.abilities.OrderBy(x => x.id).ToArray();

        StartCoroutine(CreateCell(abilities));
    }

    private IEnumerator CreateCell(EquipmentData[] abilities)
    {
        foreach (Transform equipment in openAbility) Destroy(equipment.gameObject);
        foreach (Transform equipment in closeAbility) Destroy(equipment.gameObject);
        
        foreach (var ability in abilities)
        {
            Transform transformEquipment = ability.IsOpen ? openAbility : closeAbility;
            var cellObject = Instantiate(prefabCell, transformEquipment);
            cellObject.GetComponent<Button>().onClick.AddListener(() => AudioMenu.instance.PlayButtonDefault());
            var cell = cellObject.GetComponent<CellAbility>();
            cell.Init(ability.id);
            yield return new WaitForSeconds(0.05f);
        }
    }

    public override void EnterView()
    {
        UpdateCells();
        windowUpgrade.gameObject.SetActive(false);
    }
}
