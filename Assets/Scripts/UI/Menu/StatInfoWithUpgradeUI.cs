using TMPro;
using UnityEngine;

public class StatInfoWithUpgradeUI : StatInfoUI
{
    [SerializeField]
    private TextMeshProUGUI valueNext;


    public override void UpdateStat(int level)
    {
        base.UpdateStat(level);
        valueNext.text = Stat.GetValue(level + 1).ToString();
    }
}
