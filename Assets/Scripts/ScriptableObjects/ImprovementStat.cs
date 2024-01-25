using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ImprovementStat", menuName = "ImprovementStat")]
public class ImprovementStat : ScriptableObject 
{
    public int id;
    public Sprite icon;
    public string title;
    public float step;
    public int Level => DataManager.instance.gameData.improvements.Where(x => x.id == id).FirstOrDefault().level;
    public RareType rare;

    public float Value => step * Level;
}