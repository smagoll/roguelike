using UnityEngine;
using UnityEngine.Localization;

public abstract class Upgrade : ScriptableObject
{
    public Sprite icon;
    public RareType rare;
    public abstract UpgradeType UpgradeType { get; }
    public LocalizedString title;
    public string description;

    public abstract void Action();
}