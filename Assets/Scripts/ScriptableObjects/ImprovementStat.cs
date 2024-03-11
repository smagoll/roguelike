using System.Linq;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ImprovementStat", menuName = "ImprovementStat")]
public class ImprovementStat : ScriptableObject 
{
    public int id;
    public Sprite icon;
    public LocalizedString title;
    public float step;
    public int Level => DataManager.instance.gameData.improvements.FirstOrDefault(x => x.id == id)!.level;
    public RareType rare;
    public StatType statType;

    public float Value => step * Level;
}