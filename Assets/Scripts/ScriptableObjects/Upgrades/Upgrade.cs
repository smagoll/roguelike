using UnityEngine;

public abstract class Upgrade : ScriptableObject
{
    public Sprite icon;

    public string title;
    public int rare;
    public string description;
    public int chance;

    public abstract void Action();
}
