using TMPro;
using UnityEngine;

public class StatInfoWithUpgradeUI : StatInfoUI
{
    [SerializeField]
    private TextMeshProUGUI valueNext;


    public override void Initialize(int level, Stat stat)
    {
        base.Initialize(level, stat);
        valueNext.text = stat.GetValue(level + 1).ToString();
    }
}
