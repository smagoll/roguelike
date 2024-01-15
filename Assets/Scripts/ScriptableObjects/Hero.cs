using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Hero", menuName = "Hero")]
public class Hero : ScriptableObject
{
    public Sprite sprite;
    public int hp;
    public float speed;
    public float evasion;
    public RuntimeAnimatorController animator;
}
