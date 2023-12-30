using UnityEngine;

public abstract class Upgrade : ScriptableObject
{
    public string title;
    public string description;
    public int chance;

    public bool isWeapon;
    public bool isAbility;

    public abstract void Action();
}
