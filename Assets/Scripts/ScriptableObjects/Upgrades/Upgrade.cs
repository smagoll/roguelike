using UnityEngine;
using UnityEngine.Localization;

public abstract class Upgrade : ScriptableObject
{
    public Sprite icon;
    public RareType rare;
    public abstract UpgradeType UpgradeType { get; }
    public LocalizedString title;
    public LocalizedString description;

    public virtual LocalizedString Description => description;

    public abstract void Action();
}