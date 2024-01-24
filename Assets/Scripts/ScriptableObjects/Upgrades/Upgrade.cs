using UnityEngine;

public abstract class Upgrade : ScriptableObject
{
    public Sprite icon;
    public RareType rare;
    public abstract UpgradeType UpgradeType { get; }
    public string title;
    public string description;

    public abstract void Action();
}