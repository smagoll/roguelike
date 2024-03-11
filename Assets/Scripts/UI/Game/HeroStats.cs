using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using Zenject;

public class HeroStats : MonoBehaviour
{
    [SerializeField]
    private Transform listStatsTransform;
    [SerializeField]
    private StatInfoUI statInfoUI;

    private void OnEnable()
    {
        SetStats();
    }

    private void SetStats()
    {
        foreach (Transform stat in listStatsTransform) Destroy(stat.gameObject);
        var hero = DataManager.instance.heroes.FirstOrDefault(x => x.Id == DataManager.instance.gameData.equipmentSelected.id_hero);
        if (hero != null)
            foreach (var stat in hero.stats)
            {
                var statInfo = Instantiate(statInfoUI, listStatsTransform);
                statInfo.Initialize(stat);
            }
    }
    
}
