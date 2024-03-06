using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatInfoUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI value;
    [SerializeField]
    private Image icon;

    public Stat Stat { get; set; }


    public void Initialize(int level, Stat stat)
    {
        Stat = stat;
        UpdateStat(level);
        icon.sprite = DataManager.instance.improvements.FirstOrDefault(x => x.statType == stat.Type)?.icon;
    }

    public virtual void UpdateStat(int level)
    {
        value.text = Stat.GetValue(level).ToString();
    }
}
