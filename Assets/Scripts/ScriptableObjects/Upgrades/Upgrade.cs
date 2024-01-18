using UnityEngine;

public abstract class Upgrade : ScriptableObject
{
    public Sprite icon;

    public string title;
    public int rare;
    public string description;
    public int chance;

    public bool isWeapon;
    public bool isAbility;

    public abstract void Action();
}
