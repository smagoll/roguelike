using System.Collections;
using System.Linq;
using UnityEngine;

public class MenuHeroes : MenuElement
{
    [SerializeField]
    private GameObject windowUpgrade;
    [SerializeField]
    private CellHero prefabCell;
    [SerializeField]
    private Transform openCells;
    [SerializeField]
    private Transform closeCells;
    [SerializeField]
    private HeroInfoUI heroInfoUI;

    private void UpdateCells()
    {
        ClearCells();
        StopAllCoroutines();
        StartCoroutine(CreateCells());
    }

    private IEnumerator CreateCells()
    {
        foreach (var hero in DataManager.instance.gameData.heroes.OrderBy(x => x.id))
        {
            Transform transformEquipment = hero.stageForOpen <= DataManager.instance.gameData.record ? openCells : closeCells;
            var cell = Instantiate(prefabCell, transformEquipment);
            cell.Init(hero.id);
            yield return new WaitForSeconds(.1f);
        }
    }

    public override void EnterView()
    {
        windowUpgrade.SetActive(false);
        UpdateCells();
        heroInfoUI.UpdateInfo();
        heroInfoUI.gameObject.GetComponent<UIAnimation>().AnimationIn();
    }

    public override void ExitView()
    {
        
    }

    private void ClearCells()
    {
        if (openCells.transform.childCount > 0)
        {
            foreach (Transform child in openCells.transform) Destroy(child.gameObject);
        }

        if (closeCells.transform.childCount > 0)
        {
            foreach (Transform child in closeCells.transform) Destroy(child.gameObject);
        }
    }
}
