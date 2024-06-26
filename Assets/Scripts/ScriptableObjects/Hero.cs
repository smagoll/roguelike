using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "Hero", menuName = "Hero")]
public class Hero : ScriptableObject
{
    [SerializeField]
    private int id;
    public LocalizedString title;
    public Sprite sprite;

    public RuntimeAnimatorController animator;
    public UpgradeWeapon weapon;

    public Stat[] stats;

    public int Id => id;
    public bool IsOpen => DataManager.instance.gameData.heroes.Where(x => x.id == id).Select(x => x.stageForOpen <= DataManager.instance.gameData.record).FirstOrDefault();
    public float Hp => stats.FirstOrDefault(x => x.Type == StatType.HP)!.GetValue();
    public float Speed => stats.FirstOrDefault(x => x.Type == StatType.Speed)!.GetValue();
    public float Evasion => stats.FirstOrDefault(x => x.Type == StatType.Evasion)!.GetValue();
}
