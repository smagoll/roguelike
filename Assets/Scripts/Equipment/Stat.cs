using UnityEngine;

[System.Serializable]
public class Stat
{
    [SerializeField]
    private StatType type;
    [SerializeField]
    private StatUpgradeType statUpgradeType;
    [SerializeField]
    private float value;
    [SerializeField]
    private float step;
    [Header("Clamp")]
    [SerializeField]
    private float clampValue = 0;


    public float Step => step;
    public StatType Type => type;

    public float GetValue(int level)
    {
        float valueFinal = 0;

        switch (statUpgradeType)
        {
            case StatUpgradeType.Increase:
                valueFinal = Mathf.Clamp(value + step * (level - 1), float.MinValue, clampValue);
                break;
            case StatUpgradeType.Decrease:
                valueFinal = Mathf.Clamp(value - step * (level - 1), clampValue, float.MaxValue);
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