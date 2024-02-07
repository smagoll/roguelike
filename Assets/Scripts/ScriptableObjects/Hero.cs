using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Hero", menuName = "Hero")]
public class Hero : ScriptableObject
{
    [SerializeField]
    private int id;

    public Sprite sprite;

    public RuntimeAnimatorController animator;
    public UpgradeWeapon weapon;

    public Stat[] stats;

    public int Id => id;
    public bool IsOpen => DataManager.instance.gameData.heroes.Where(x => x.id == id).FirstOrDefault().isOpen;
    public float Hp => stats.FirstOrDefault(x => x.Type == StatType.HP).GetValue();
    public float Speed => stats.FirstOrDefault(x => x.Type == StatType.Speed).GetValue();
    public float Evasion => stats.FirstOrDefault(x => x.Type == StatType.Evasion).GetValue();
}

public interface IStats
{
    Stat[] Stats { get; }
}
