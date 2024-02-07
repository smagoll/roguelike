using System;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class Stat
{
    [SerializeField]
    private StatType statType;
    [SerializeField]
    private StatUpgradeType statUpgradeType;
    [SerializeField]
    private float value;
    [SerializeField]
    private float step;
    [Header("Clamp")]
    [SerializeField]
    private float clampValue = 0;

    private ImprovementStatData[] improvements;


    public float Step => step;
    public StatType Type => statType;
    public float Percent
    {
        get
        {
            var improvement = DataManager.instance.improvements.FirstOrDefault(x => x.statType == statType);
            return improvement == null ? 0 : improvement.Value;
        }
    }

    public Stat(StatType statType)
    {
        this.statType = statType;
    }

    public float GetValue(int level)
    {
        float valueFinal = 0;

        switch (statUpgradeType)
        {
            case StatUpgradeType.Increase:
                valueFinal = value + step * (level - 1);
                valueFinal = ((float)Math.Round(valueFinal * (1 + Percent / 100), 2));
                valueFinal = Mathf.Clamp(valueFinal, float.MinValue, clampValue);
                break;
            case StatUpgradeType.Decrease:
                valueFinal = value - step * (level - 1);
                valueFinal = ((float)Math.Round(valueFinal * (1 - Percent / 100), 2));
                valueFinal = Mathf.Clamp(valueFinal, clampValue, float.MaxValue);
                break;
        }

        return valueFinal;
    }
    
    public float GetValue()
    {
        float valueFinal = value;

        switch (statUpgradeType)
        {
            case StatUpgradeType.Increase:
                valueFinal = ((float)Math.Round(valueFinal * (1 + Percent / 100), 2));
                valueFinal = Mathf.Clamp(valueFinal, float.MinValue, clampValue);
                break;
            case StatUpgradeType.Decrease:
                valueFinal = ((float)Math.Round(valueFinal * (1 - Percent / 100), 2));
                valueFinal = Mathf.Clamp(valueFinal, clampValue, float.MaxValue);
                break;
        }

        return valueFinal;
    }
}

public enum StatUpgradeType
{
    Increase,
    Decrease
}